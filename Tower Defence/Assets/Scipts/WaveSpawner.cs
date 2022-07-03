using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};


    [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float delay;
        public float Wave_Rest_Time;
    }

    public Wave[] waves;

    private int nextWave = 0;
    public float countdown = 5.5f;
    public SpawnState state = SpawnState.COUNTING;
    public TextMeshProUGUI CountText;
    private bool end = false;

    private void Update()
    {
        if (end)
        {
            return;
        }
        if (countdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {

                StartCoroutine( SpawnWave( waves[nextWave] ) );
                if (nextWave+1 > waves.Length -1)
                {
                    end = true;
                    Debug.Log("End of level");
                    countdown = 0;
                }
                else
                {
                    countdown = waves[nextWave].Wave_Rest_Time;
                    nextWave++;
                }

            }
        }
        else
        {
            countdown -= Time.deltaTime;
            CountText.text = countdown.ToString("0");

        }
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.SPAWNING;
        Debug.Log("Wave Incoming!!");
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.delay);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }

}
