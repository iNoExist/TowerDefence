using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int Level;
    [Header("Money")]
    public static int Money;
    public int startMoney = 500;
    [Header("Lives")]
    public static float Lives;
    public float startLives = 100f;
    [HideInInspector]
    public static int Waves;
    [HideInInspector]
    public static bool WavesEnded;
    [HideInInspector]
    public static int Level_;

    private void Start()
    {
        Level_ = Level;
        Money = startMoney;
        Lives = startLives;
        WavesEnded = false;
        Waves = 0;
    }
}
