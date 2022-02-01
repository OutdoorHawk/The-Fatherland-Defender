using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed = 15f;
    [SerializeField] protected GameObject _impactEffect;
    [SerializeField] protected int _damageAmount = 10;

    protected Transform _target;
  



    public void Seek(Transform target)
    {
        _target = target;
    }

    protected void Update()
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


    protected void HitTarget(Transform enemy)
    {
        if (enemy != null)
        {
            enemy.parent.transform.SendMessage("TakeDamage", _damageAmount);

        }

        GameObject impactEffect = (GameObject)Instantiate(_impactEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 2f);

        Destroy(gameObject);
    }



   
}
