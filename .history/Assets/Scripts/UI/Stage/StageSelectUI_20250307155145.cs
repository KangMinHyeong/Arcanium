using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] int ChapterNum = 0;
    [SerializeField] GameObject StageButtonPrefab;

    void OnEnable()
    {
        // Stage 개수
        UpdateStageButton();
    }

    void UpdateStageButton()
    {

    }
}
