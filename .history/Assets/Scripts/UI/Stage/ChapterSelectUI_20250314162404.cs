using UnityEngine;

public class ChapterSelectUI : MonoBehaviour
{
    [SerializeField] GameObject ChapterButtonPrefab;

    void OnEnable()
    {
        // Chapter 잠금 확인
        UpdateChapterButton();
    }

    void UpdateChapterButton()
    {
        int TotalChapter = 3; // 임시 변수 3챕터
        int enabledChapter = GameManager.Instance.clearChapterNumber;

        for(int i = 0; i<TotalChapter; i++)
        {
            var ChapterButton = Instantiate(ChapterButtonPrefab, transform);

            var StageSelectUI = ChapterButton.GetComponentInChildren<StageSelectUI>();
            StageSelectUI.ChapterNum = i;
            StageSelectUI.UpdateStageButton();

            if( i <= enabledChapter)
            {
                StageSelectUI.SetActive(true); // 활성화
            }
            else
            {
                StageSelectUI.SetActive(false); // 잠금
            }
        }
    }
}
