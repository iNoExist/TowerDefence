using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        Time.timeScale = 0f;
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.unscaledDeltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        Time.timeScale = 1f;
    }

    IEnumerator FadeOut(int scene)
    {
        Time.timeScale = 0f;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
