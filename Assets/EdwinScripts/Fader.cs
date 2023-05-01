using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image panel;
    public float fadeDuration = 1f;

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine(1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCoroutine(0));
    }

    private IEnumerator FadeCoroutine(float targetAlpha)
    {
        float startAlpha = panel.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, newAlpha);
            yield return null;
        }

        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, targetAlpha);
    }
}
