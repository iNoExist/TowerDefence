using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public ScreenFader screenFader;
    public void L1()
    {
        screenFader.FadeTo(1);
    }
    public void L2()
    {
        screenFader.FadeTo(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
