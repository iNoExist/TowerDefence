using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public ScreenFader screenFader;
    public TextMeshProUGUI WavesText;
    void OnEnable()
    {
        WavesText.text = PlayerStats.Waves.ToString();
    }

    public void Continue()
    {
        int next = PlayerStats.Level_ + 1;
        SceneManager.LoadScene(next);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        screenFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        screenFader.FadeTo(0);
    }
}
