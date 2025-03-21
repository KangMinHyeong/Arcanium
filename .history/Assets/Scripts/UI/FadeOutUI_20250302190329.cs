using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField] float fadeDuration = 2.0f;

    TextMeshPro Contents;
    float InitAlpha = 1.0f;

    void OnEnable() 
    {
        Contents = GetComponentInParent<TextMeshPro>();
        InitAlpha = Contents.alpha;
        
        StartCoroutine(FadeOutCoroutine());
    }
    

    // Update is called once per frame
    IEnumerator FadeOutCoroutine()
    {
        
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            Contents.alpha = Mathf.Lerp(InitAlpha, 0.0f, elapsedTime / fadeDuration);
            yield return null;
        }

        Contents.alpha = 0.0f;
    }
}
