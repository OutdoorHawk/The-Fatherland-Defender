using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Turret
{
   

    [SerializeField] private  ParticleSystem _fireParticle;
    [SerializeField] private float _fireHitRange;
    [SerializeField][Range(0,1)] private float _slowAmount = 0.5f;
    [SerializeField] private int _damagePerSec = 1;

   

    private ParticleSystem _fireEffect;

    private ParticleSystem.EmissionModule _emission;

    

    private new void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

       
            
        
    }

    private new void Update()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turretRotationSpeed).eulerAngles;

        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        Shoot();
       

    }

    private new void Shoot()
    {


        if (_fireEffect == null)
        {
            _fireEffect = (ParticleSystem)Instantiate(_fireParticle, _firePoint.position, _firePoint.rotation, _firePoint);
            _emission = _fireEffect.emission;

        }

        Collider[] enemies = Physics.OverlapSphere(_target.position, _fireHitRange);

        foreach (Collider e in enemies)
        {

            if (e.CompareTag("Enemy"))
            {
                if (_fireCountdown <= 0f)
                {

                    e.transform.parent.transform.SendMessage("Slow", _slowAmount);
                    e.transform.parent.transform.SendMessage("TakeDamage", _damagePerSec);

                    _fireCountdown = _fireRate;
                }

                _fireCountdown -= Time.deltaTime;




                
               
            }

        }



    }

    private new void UpdateTarget()
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
            if (_fireEffect !=null)
            {
                _emission.enabled = false;
                Destroy(_fireEffect, 1.5f);
            }
            
            _target = null;
        }

       

    }

   
}
