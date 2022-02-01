using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject _thisUI;
    [SerializeField] private Text _upgradeCostText;
    [SerializeField] private GameObject _upgradeText;
    [SerializeField] private Button _upgradeButton;

    [SerializeField] private Text _sellCostText;

    private Node _target;

    private Vector3 _uiPositionOffset;

    private void Awake()
    {
        _uiPositionOffset = new Vector3(0.14f, 0, 0.53f);
    }

    public void SetTarget(Node target)
    {
        //if (GameProcess.gameFinished)
        //{
        //    Hide();
        //    return;
        //}
        _target = target;

        transform.position = target.GetBuildPosition() + _uiPositionOffset;


        if (!target._isUpgraded)
        {
            _upgradeCostText.text = "\n $" + target._curretTurretFromList.upgradeCost;
            _upgradeButton.interactable = true;
            _upgradeText.SetActive(true);
        }
        else
        {
            _upgradeText.SetActive(false);
            _upgradeButton.interactable = false ;
            _upgradeCostText.text = "Upgraded";
        }

        _sellCostText.text = "\n $" + target._curretTurretFromList.sellCost;



        _thisUI.SetActive(true);
    }

    public void Hide()
    {
        _thisUI.SetActive(false);

    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        Building.instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        Building.instance.DeselectNode();
    }
}
