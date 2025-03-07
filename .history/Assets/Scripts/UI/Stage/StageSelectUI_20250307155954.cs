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
        int totalstage = GameManager.Instance.clearStageNumber;
        int ChapterStageNum = totalstage - (ChapterNum * 10); 

        for(int i = 0; i<10; i++)
        {
            var StageButton = Instantiate(StageButtonPrefab, transform);

            if(i > ChapterStageNum)
            {
                // StageButton 잠금
            }
            else
            {
                StageButton.GetComponentInChildren<StageButton>().stageNumber = totalstage;
                // StageButton totalstage번호 부여
            }
        }
    }
}
