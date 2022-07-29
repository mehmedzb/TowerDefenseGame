using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;

    
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetdistance = Vector3.Distance(transform.position , enemy.transform.position);
            if(targetdistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetdistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetdistance = Vector3.Distance(transform.position , target.position);
        weapon.LookAt(target);
        if(targetdistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
