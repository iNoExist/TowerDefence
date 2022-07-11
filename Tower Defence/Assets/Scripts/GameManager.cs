using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshPro MoneyText;
    public TextMeshPro LivesText;
    [Header("Assign")]
    public GameObject GameOverUI;

    [HideInInspector]
    public static bool GameOver;

    void Start()
    {
        GameOver = false;
        InvokeRepeating("UpdateText", 0f, 0.5f);
    }
    public void UpdateText()
    {
        MoneyText.text = ("$" + PlayerStats.Money);
        if (PlayerStats.Lives < 0)
        {
            PlayerStats.Lives = 0;
        }
        LivesText.text = ("Health " + PlayerStats.Lives + "%");
    }

    void Update()
    {
        if(PlayerStats.Lives <= 0 && !GameOver)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameOver = true;
        GameOverUI.SetActive(true);

    }
}
