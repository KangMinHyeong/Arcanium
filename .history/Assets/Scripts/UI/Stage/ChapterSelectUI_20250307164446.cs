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
        // 일단은 3챕터
        int TotalChapter = 3;
        int enabledChapter = GameManager.Instance.clearChapterNumber;

        for(int i = TotalChapter-1; i>=0; i--)
        {
            var ChapterButton = Instantiate(ChapterButtonPrefab, transform);

            if( i <= enabledChapter)
            {
                ChapterButton.GetComponentInChildren<StageSelectUI>().SetActive(true); // 활성화
            }
            else
            {
                ChapterButton.GetComponentInChildren<StageSelectUI>().SetActive(false);
                // 잠금
            }
        }
    }
}
