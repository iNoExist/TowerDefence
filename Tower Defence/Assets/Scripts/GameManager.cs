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
    public GameObject GameWonUI;
    public GameObject PauseUI;

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
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!GameOver && (Time.timeSinceLevelLoad > 0.9f))
            {
                TogglePause();
            }
        }
        if(PlayerStats.WavesEnded)
        {
            if (!enemyLeft())
            {
                Won();
            }
        }
    }

    public bool enemyLeft()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy")).Length == 0)
        {
            return false;
        }
        return true;
    }

    public void TogglePause()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);
        if(PauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    void EndGame()
    {
        GameOver = true;
        GameOverUI.SetActive(true);
    }
    void Won()
    {
        GameOver = true;
        GameWonUI.SetActive(true);
        PlayerPrefs.SetInt(PlayerStats.Level_ + "Won", 1);
        PlayerPrefs.Save();
    }
}
