using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [Header("Path and moving")]
    [Space]
    [SerializeField] protected float _speed = 10f;

    [SerializeField] [Range(0,3)]protected int _pathIndex;
   

    protected Transform _target;

    protected int _waypointIndex = 0;

    protected Waypoints _waypoints;
    protected int _numberOfPoints = 0;

    
    public int spawnPointIndex //Может использоваться при наличии нескольких точек спавна
    {
        get { return spawnPointIndex; }
    }

  

    [Header("Health and damage")]
    [Space]

    [SerializeField] protected int _damageToPlayer = 1;
    [SerializeField] protected float _maxHealth = 100;
    protected float _currentHealth;

    [SerializeField] protected Canvas _healthBars;
    [SerializeField] protected Image _healthBar;

    [Header("SlowModifier")]
    [Space]

   
    [SerializeField] protected float _slowDuration = 2f;
    protected float _slowTimer;
    protected float _slowModifier = 1f;

    [Header("Other")]
    [Space]

    [SerializeField] protected GameObject _deathParticles;
    [SerializeField] protected int _moneyGain = 50;

   
    protected Vector3 _lookOffset;

    

    



    protected void Awake()
    {
        _waypoints = GetComponent<Waypoints>();

        _currentHealth = _maxHealth;


        _target = Waypoints.points[_pathIndex][0];

        transform.LookAt(_target);

        _lookOffset = (Camera.main.transform.position - transform.position);

        _lookOffset = new Vector3(_lookOffset.x + 50, 0, 0);

        _slowModifier = 1f;

    }



    protected void Update()
    {
      

       
        Vector3 direction = _target.position - transform.position;

        transform.Translate(direction.normalized * _speed * _slowModifier * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }


    }

    protected void LateUpdate()
    {
        SlowCheck();
    }

    protected void FixedUpdate()
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

  
    protected void GetNextWaypoint()
    {

        if (_waypointIndex >= Waypoints.points[_pathIndex].Length - 1)
        {
            EndPath();
            return;
        }


        _waypointIndex++;
        _target = Waypoints.points[_pathIndex][_waypointIndex];
        transform.LookAt(_target);
        _healthBars.transform.rotation = Quaternion.Euler(_lookOffset);

    }

    private void EndPath()
    {
        if (Stats.HealthPoints > 0)
        {
            Stats.HealthPoints -= _damageToPlayer;
        }


        Stats.EnemiesKilled--;
        Stats.Money -= _moneyGain;
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            
            EnemyDead();
        }
    }

    public void Slow(float slowAmount)
    {

        _slowModifier = slowAmount;

        _slowTimer = Time.time;
    }

    private void SlowCheck()
    {
        if (Time.time > _slowTimer + _slowDuration)
        {
            _slowModifier = 1;
        }
    }

    private void EnemyDead()
    {
       
        
        GameObject _deathEffect = (GameObject)Instantiate(_deathParticles, transform.position, Quaternion.identity);
        Destroy(_deathEffect, 5f);

       

        Destroy(gameObject);
    }

    protected void OnDestroy()
    {
        Stats.EnemiesKilled++;
        Stats.Money += _moneyGain;
        WaveSpawner.enemiesAlive--;
    }
}
