using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Projectiles")]
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public GameObject projectilePrefab;

    [Header("laser")]
    public bool useLaser = false;
    public LineRenderer LineRend;
    public ParticleSystem LaserEff;
    public Light impactLight;
    public float damageOverTime = 1f;
    public float SpeedPct = 0.75f;

    [Header("UnitySetUp")]
    public string EnemyTag = "Enemy";
    public Transform rotatePart;
    public float turnspeed = 9f;
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
            targetEnemy = ClosestEnemy.GetComponent<Enemy>();
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
            if(useLaser)
            {
                if(LineRend.enabled)
                {
                    LineRend.enabled = false;
                    LaserEff.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockOn();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOn()
    {
        Vector3 dir = (target.position - transform.position);
        Quaternion LookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, LookRotation, Time.deltaTime * turnspeed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(SpeedPct);

        if(!LineRend.enabled)
        {
            LineRend.enabled = true;
            LaserEff.Play();
            impactLight.enabled = true;
        }
        LineRend.SetPosition(0, firepoint.position);
        LineRend.SetPosition(1, target.position);

        Vector3 dir = firepoint.position - target.position;
        LaserEff.transform.rotation = Quaternion.LookRotation(dir);
        LaserEff.transform.position = target.position + dir.normalized;
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
