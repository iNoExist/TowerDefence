using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("UnitySetUp")]
    public string EnemyTag = "Enemy";
    public Transform rotatePart;
    public float turnspeed = 9f;
    public GameObject projectilePrefab;
    public Transform firepoint;
    

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject ClosestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                ClosestEnemy = enemy;
            }
        }
        if (ClosestEnemy != null && shortestDistance <= range)
        {
            target = ClosestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    void Update()
    {
        if (target == null)
        {
            return;
        }
        //LOCK ON MECHANISM
        Vector3 dir = (target.position - transform.position);
        Quaternion LookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, LookRotation, Time.deltaTime * turnspeed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void shoot ()
    {
        GameObject ProjectileGo = (GameObject)(Instantiate(projectilePrefab, firepoint.position, firepoint.rotation));
        Projectile projectile = ProjectileGo.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
