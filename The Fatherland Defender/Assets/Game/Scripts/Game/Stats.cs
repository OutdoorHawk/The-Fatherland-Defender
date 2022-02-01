using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int Money;
    public static int HealthPoints;
    public static int WavesSurvived;
    public static int EnemiesKilled;

    [SerializeField] private int _startMoney = 500;
    [SerializeField] private int _startHealthPoints = 20;

    

    private void Start()
    {
        Money = _startMoney;
        HealthPoints = _startHealthPoints;
        WavesSurvived = -1;
        EnemiesKilled = 0;
    }

  

}
