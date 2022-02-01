using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedMachineGun : Turret
{

 
    [SerializeField] private Transform _secondFirePoint;

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

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;

    }
    private new void Shoot()
    {

        GameObject projectileLaunch = (GameObject)Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        GameObject projectileLaunch2 = (GameObject)Instantiate(_projectilePrefab, _secondFirePoint.position, _secondFirePoint.rotation);

        GameObject fireFX1 = (GameObject)Instantiate(_fireFX, _firePoint.position, _firePoint.rotation);
        GameObject fireFX2 = (GameObject)Instantiate(_fireFX, _secondFirePoint.position, _firePoint.rotation);

        Destroy(fireFX1, 1f);
        Destroy(fireFX2, 1f);

        Projectile projectile = projectileLaunch.GetComponent<Projectile>();
        Projectile projectile2 = projectileLaunch2.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(_target);
            projectile2.Seek(_target);
        }
    }
}
