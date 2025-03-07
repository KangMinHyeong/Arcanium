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

        for(int i = 0; i<TotalChapter; i++)
        {
            var ChapterButton = Instantiate(ChapterButtonPrefab, transform);

            if( i <= enabledChapter)
            {
                // 활성화
            }
            else
            {
                // 잠금
            }
        }
    }
}
