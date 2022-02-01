using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassed : MonoBehaviour
{
    [SerializeField] private Text _wavesText;
    [SerializeField] private Text _enemiesText;

    private void OnEnable()
    {
        _wavesText.text = Stats.WavesSurvived.ToString();
        _enemiesText.text = Stats.EnemiesKilled.ToString();
    }

}
