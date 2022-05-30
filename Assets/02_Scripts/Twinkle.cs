using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    float fadeTime = 0.1f;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("TwinkleLoop");
    }

    IEnumerator TwinkleLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeEffect(1, 0));

            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }

    IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = sr.color;
            color.a = Mathf.Lerp(start, end, percent);
            sr.color = color;

            yield return null;
        }
    }

    void Update()
    {
        
    }
}
