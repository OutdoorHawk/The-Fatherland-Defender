using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  
    [Header("Enemy Detection")]
    [Space]

    [SerializeField] protected float _range = 1f;
    [SerializeField] protected LayerMask _whatIsDamageable;
    [SerializeField] protected string _enemyTag = "Enemy";

    protected Transform _target;

    [Header("Turret Rotation")]
    [Space]

    [SerializeField] protected Transform _partToRotate;
    [SerializeField] protected float _turretRotationSpeed = 10f;

    [Header("Fire")]
    [Space]

    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected GameObject _fireFX;

    protected float _fireCountdown = 0f;
    






    protected void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected void Update()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation =Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turretRotationSpeed).eulerAngles;

        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;

    }

    protected void Shoot()
    {
        
        GameObject projectileLaunch = (GameObject)Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        Projectile projectile = projectileLaunch.GetComponent<Projectile>();

        GameObject fireFX = (GameObject)Instantiate(_fireFX, _firePoint.position, _firePoint.rotation);

        Destroy(fireFX, 1f);
        
        if (projectile != null)
        {
            projectile.Seek(_target);
        }
    }

    protected void UpdateTarget()
    {
        

        Collider[] enemies = Physics.OverlapSphere(transform.position, _range, _whatIsDamageable);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (Collider enemy in enemies)
        {

            if (enemy.CompareTag(_enemyTag))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
               
               
                if (distanceToEnemy < shortestDistance)
                {
                   
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy.gameObject;
                  
                }

            }
            
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }

       

    }


    protected void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(transform.position, _range);
    }

}

