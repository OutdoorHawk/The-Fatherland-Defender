using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text _healthText;

    

   
    void FixedUpdate()
    {
        _healthText.text = Stats.HealthPoints.ToString();
    }
}
