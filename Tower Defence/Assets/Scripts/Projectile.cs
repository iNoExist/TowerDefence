using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float ExploRadi = 0f;
    public float damage = 1f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        if (ExploRadi > 0f)
        {
            explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.TakeDamage(damage);
    }

    void explode()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, ExploRadi);
        foreach (Collider collider in hitObjects)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExploRadi);
    }
}
