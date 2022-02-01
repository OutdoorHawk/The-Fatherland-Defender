using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



[RequireComponent(typeof(Renderer))]

public class Node : MonoBehaviour
{

    [Header("Color Change")]
    [Space]

    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _noMoneyColor;
    private Renderer _renderer;
    private Color _startColor;

    [Header("Turrets")]
    [Space]

    [SerializeField] private Vector3 _possitionOffset;
    [SerializeField] private Vector3 _spawnRotation;

    [HideInInspector]
    public GameObject _turret;
    [HideInInspector]
    public TurretList _curretTurretFromList;
    [HideInInspector]
    public bool _isUpgraded = false;

    Building _buildManager;

    [Header("Other")]
    [Space]

    [SerializeField] private Notifications _notifications;

    private void Start()
    {
      
        _renderer = GetComponent<Renderer>();
       
        _startColor = _renderer.material.color;
        _buildManager = Building.instance;
        
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + _possitionOffset;
    }

    public Quaternion GetBuildRotation()
    {
        return Quaternion.Euler(_spawnRotation);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (GameProcess.gamePaused || GameProcess.gameFinished)
        {
            return;
        }

        if (_turret !=null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        


        if (!_buildManager.CanBuild)
        {
            return;
        }

        

        BuildTurret(_buildManager.GetTurretToBuild()); //≈сли все услови€ строительства соблюдены, то строим турель на выбранном участке


    }

    private void BuildTurret (TurretList turretFromTurretList)
    {

        if (Stats.Money < turretFromTurretList.cost)
        {
            _notifications.NoMoney();
            return;
        }

        Stats.Money -= turretFromTurretList.cost;

        GameObject newTurret = (GameObject)Instantiate(turretFromTurretList.prefab, GetBuildPosition(), GetBuildRotation());

        _turret = newTurret; // ѕрисваиваем участку турель, которую построили на нем

        _curretTurretFromList = turretFromTurretList;

        GameObject _buildEffect = (GameObject)Instantiate(_buildManager.buildParticlePrefab, GetBuildPosition() + new Vector3(0,1,0), Quaternion.identity);
        Destroy(_buildEffect, 5f);
    }

    public void UpgradeTurret()
    {
        if(Stats.Money < _curretTurretFromList.upgradeCost)
        {
            _notifications.NoMoney();
            return;
        }

        Stats.Money -= _curretTurretFromList.upgradeCost;

        //”даление старой турели
        Destroy(_turret);

        //—павн улучшенной турели
        GameObject upgradedTurret = (GameObject)Instantiate(_curretTurretFromList.upgradedPrefab, GetBuildPosition(), GetBuildRotation());

        _turret= upgradedTurret; 

        GameObject _buildEffect = (GameObject)Instantiate(_buildManager.buildParticlePrefab, GetBuildPosition(), Quaternion.identity);

        Destroy(_buildEffect, 5f);

        _isUpgraded = true;


    }

    public void SellTurret()
    {
        Stats.Money += _curretTurretFromList.sellCost;
        _isUpgraded = false;

        GameObject _sellEffect = (GameObject)Instantiate(_buildManager.sellParticlePrefab, GetBuildPosition(), Quaternion.identity);

        Destroy(_sellEffect, 5f);

        Destroy(_turret);
        _turret = null;
       

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoney)
        {
            _renderer.material.color = _hoverColor;
            
        }
        else
        {
            _renderer.material.color = _noMoneyColor;
        }

       
       
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
       
    }


}
