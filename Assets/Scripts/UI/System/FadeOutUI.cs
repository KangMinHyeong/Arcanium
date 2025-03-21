using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1.5f;

    TextMeshProUGUI Contents;
    float InitAlpha = 1.0f;

    void Start()
    {
        
    }

    void OnEnable() 
    {
        Contents = GetComponentInParent<TextMeshProUGUI>();
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
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
        Contents.alpha = InitAlpha;
    }
}
