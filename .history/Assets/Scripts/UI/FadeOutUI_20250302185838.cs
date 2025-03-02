using System.Collections;
using UnityEngine;

public class FadeOutUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() 
    {
        StartCoroutine(FadeOutCoroutine());
    }
    

    // Update is called once per frame
    IEnumerator FadeOutCoroutine()
    {
        float startAlpha = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
