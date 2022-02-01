using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
   

    void FixedUpdate()
    {
        _moneyText.text = "$" + Stats.Money.ToString();
    }
}
