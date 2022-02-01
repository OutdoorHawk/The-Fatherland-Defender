using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive;


    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int _moneyForClearWave = 0;

 
    [SerializeField] private Text _waveCountdownText;

    [Header("Main wave settings")]
    [SerializeField] private Wave[] _waves;

    [Header("For extra types of enemies in a wave")]
    [SerializeField] private Wave[] _wavesAdditional;

    [SerializeField] private GameObject[] _enemyPaths;

    private Enemy _curretEnemy;

    private int _waveNumber = 0;

    private float _countdown;

    private int _enemySpawnPoint;

    private int _enemyIndex;

    private int _lastRoundHP;

    private void Awake()
    {
        enemiesAlive = 0;
        _countdown = 10;

        

       
    }

    private void Start()
    {
        StartCoroutine(SpawnGhostPaths());


    }

    private void Update()
    {
       
        if (enemiesAlive > 0)
        {
            
            return;
        }
        else
        {
            if(_countdown == _timeBetweenWaves)
            {
               

               
                if (Stats.HealthPoints == _lastRoundHP)
                {
                   
                    Stats.Money += _moneyForClearWave;

                }



            }
        }
       
       

        if (_countdown <= 0 && !GameProcess.gameFinished)
        {
            if (_waveNumber < _waves.Length)
            {
                StartCoroutine(SpawnWave());

                if (_wavesAdditional.Length > 0)
                {
                    StartCoroutine(SpawnAdditionalWave());
                }

                
                
               
                _waveNumber++;
                _countdown = _timeBetweenWaves;
                _lastRoundHP = Stats.HealthPoints;
                return;


            }
            else
            {
               

                    GameProcess.gameFinished = true;
                    return;
                
            }


          
           






        }



        _countdown -= Time.deltaTime;

        
        
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        _waveCountdownText.text = Mathf.Round(_countdown).ToString();
    }

 private void  LateUpdate()

    {

    }

    IEnumerator SpawnWave()
    {
        Stats.WavesSurvived++;

        Wave wave = _waves[_waveNumber];

        


        for (int i = 0; i < wave.amount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

            
        }

      
       
        
    }

    private IEnumerator SpawnAdditionalWave()
    {
        
            Wave waveAdv = _wavesAdditional[_waveNumber];

       

            for (int i = 0; i < waveAdv.amount; i++)
            {
            if (waveAdv.enemy != null)
            {
                SpawnEnemy(waveAdv.enemy);
            }
                
                yield return new WaitForSeconds(1f / waveAdv.rate);
            }
        

    }

    private void SpawnEnemy(GameObject enemy)
    {
       
        Instantiate(enemy, _spawnPoints[0].position, Quaternion.identity);
        enemiesAlive++;
    }

    private IEnumerator SpawnGhostPaths()
    {

        for (int i = 0; i < _enemyPaths.Length; i++)
        {
            Instantiate(_enemyPaths[i], _spawnPoints[0].position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }

    }



}
