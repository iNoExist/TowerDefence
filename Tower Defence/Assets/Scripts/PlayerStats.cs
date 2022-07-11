using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [Header("Money")]
    public static int Money;
    public int startMoney = 500;
    [Header("Lives")]
    public static float Lives;
    public float startLives = 100f;
    [HideInInspector]
    public static int Waves;
    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Waves = 0;
    }
}
