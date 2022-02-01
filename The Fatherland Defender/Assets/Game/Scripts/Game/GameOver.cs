using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _wavesText;

    private void OnEnable()
    {
        _wavesText.text = Stats.WavesSurvived.ToString();
    }



    
}
