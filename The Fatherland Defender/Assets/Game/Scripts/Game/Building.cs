using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public static Building instance;
    
    private TurretList _turrentTobuild;
    private Node _selectedNode;


    [SerializeField] private NodeUI _nodeUI;

   public GameObject buildParticlePrefab;
    public GameObject sellParticlePrefab;


    public bool CanBuild { get { return _turrentTobuild != null; } }

    public bool HasMoney { get { return Stats.Money >= _turrentTobuild.cost; } }

    private void Awake()
    {

        instance = this;

    }

    public void SelectNode  (Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _turrentTobuild = null;
        _nodeUI.SetTarget(node);
    }


    public void SelectTurretToBuild(TurretList turret)
    {
        _turrentTobuild = turret; //Присваеваем турель, которую выбрали в магазине к приватной переменной
        _selectedNode = null;
        _nodeUI.Hide();
    }

    

    public void DeselectNode()
    {
        _selectedNode = null;
        _nodeUI.Hide();
    }


    public TurretList GetTurretToBuild()
    {
        return _turrentTobuild;
    }

}
