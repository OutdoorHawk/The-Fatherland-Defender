
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    private Building _buildManager;

    [SerializeField] TurretList _machineGunTurret;
    [SerializeField] TurretList _heavyTurret;
    [SerializeField] TurretList _flamethrower;

    [SerializeField] Text[] shopItemsCost;

    private void Start()
    {
        _buildManager = Building.instance;
        shopItemsCost[0].text = "$" + _machineGunTurret.cost.ToString();
        shopItemsCost[1].text = "$" + _heavyTurret.cost.ToString();
        shopItemsCost[2].text = "$" + _flamethrower.cost.ToString();
    }

    //Методы вызываются при нажании на кнопку турели
    public void SelectMachineGunTurret()
    {
       

        _buildManager.SelectTurretToBuild(_machineGunTurret); //Они передают выбранный тип турели в скрипт строителя 
    }

    public void SelecteHeavyTurret()
    {
        

        _buildManager.SelectTurretToBuild(_heavyTurret);
    }

    public void SelectFlamethrowerTurret()
    {


        _buildManager.SelectTurretToBuild(_flamethrower);
    }

}
