using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI WavesText;
    void OnEnable()
    {
        WavesText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Debug.Log("Menu");
    }
}
