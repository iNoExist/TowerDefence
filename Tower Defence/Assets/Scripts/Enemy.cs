using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float StartSpeed = 10f;
    public float StartHealth;
    public float attack = 1f;
    public int reward = 10;
    [Header("Effect")]
    public GameObject DeathEffect;
    [Header("UnityStuff")]
    public Image HealthBar;
    public GameObject HealthUI;

    private Transform target;
    private int waypointIndex = 0;
    private float damping = 5f;
    private bool dieOnce = false;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;
    void Start()
    {
        target = Waypoints.points[0];
        speed = StartSpeed;
        health = StartHealth;
    }

    public void Slow(float pct)
    {
        speed = StartSpeed * (pct);
    }
    IEnumerator WaitFor3()
    {
        yield return new WaitForSeconds(3);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / StartHealth;
        if (health <= 0 && !dieOnce)
        {
            dieOnce = true;
            Die();
        }
    }

    public void Die()
    {
        GameObject effect = (GameObject)Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(effect, 3f);
        PlayerStats.Money += reward;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        speed = StartSpeed;

        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        Vector3 v = new Vector3(-200, 90, -35);
        HealthUI.transform.LookAt(v);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNext();
        }
    }

    void GetNext()
    {
        if (waypointIndex >= (Waypoints.points.Length - 1))
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives -= attack;
    }
}
