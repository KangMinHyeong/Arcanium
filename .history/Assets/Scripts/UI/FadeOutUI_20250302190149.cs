using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField] float fadeDuration = 2.0f;
    
    TextMeshPro Contents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() 
    {
        Contents = GetComponentInParent<TextMeshPro>();

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
            Contents.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
