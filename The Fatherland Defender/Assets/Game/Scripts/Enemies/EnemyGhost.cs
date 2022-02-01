using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
     

    private new void LateUpdate()
    {
       
    }

    private new void FixedUpdate()
    {
        
    }



    private new void Update()
    {



        Vector3 direction = _target.position - transform.position;

        transform.Translate(direction.normalized * _speed * _slowModifier * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }


    }

    private new void GetNextWaypoint()
    {

        if (_waypointIndex >= Waypoints.points[_pathIndex].Length - 1)
        {

            Destroy(gameObject);
            return;
        }


        _waypointIndex++;
        _target = Waypoints.points[_pathIndex][_waypointIndex];
        transform.LookAt(_target);
       

    }

    private new void OnDestroy()
    {
        
    }


}
