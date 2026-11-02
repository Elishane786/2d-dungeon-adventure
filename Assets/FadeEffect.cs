using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f; // Duration of the fade effect

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0); // Start fully transparent
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

     public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration); // Gradually increase alpha
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration); // Gradually decrease alpha
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
