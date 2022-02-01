using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyProjectile : Projectile
{
    [SerializeField] private float _range = 2f;

    //[SerializeField][Range(0,1)] private float _enemySlowAmount = 1f; 

    public new void Seek(Transform target)
    {
        _target = target;
    }

    private new void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;

        }

        Vector3 direction = _target.position - transform.position;

        float distanceThisFrame = _speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
           

           
            
                
                HitTarget(_target);
                return;
            
            
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }
    private new void HitTarget(Transform enemy)
    {


        if (enemy != null)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _range);

            foreach (Collider e in enemies)
            {
                if (e.CompareTag("Enemy"))
                {
                    e.transform.parent.transform.SendMessage("TakeDamage", _damageAmount);
                    //e.transform.parent.transform.SendMessage("Slow",_enemySlowAmount);
                }
                
            }

            
                
              

           



        }

       GameObject impactEffect = (GameObject)Instantiate(_impactEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 2f);

        Destroy(gameObject);
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
