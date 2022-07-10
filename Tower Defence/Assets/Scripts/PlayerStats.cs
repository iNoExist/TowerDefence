using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 500;

    private void Start()
    {
        Money = startMoney;
    }
}
