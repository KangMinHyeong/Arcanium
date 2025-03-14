using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] GameObject StageButtonPrefab;
    [SerializeField] GameObject BlockImage;
    [SerializeField] Transform StageTransform;
    
    public int ChapterNum = 0;

    public void UpdateStageButton()
    {
        int totalstage = GameManager.Instance.clearStageNumber;
        int ChapterStageNum = totalstage - (ChapterNum * 10); 

        for(int i = 0; i<10; i++)
        {
            var StageButton = Instantiate(StageButtonPrefab, StageTransform);

            if(i > ChapterStageNum)
            {
                // StageButton 잠금
                StageButton.GetComponentInChildren<StageButton>().OnLockStageButton();
            }
            
            // StageButton totalstage번호 부여 (10개마다 챕터로 나누기)
            StageButton.GetComponentInChildren<StageButton>().SetStageNumber(ChapterNum * 10 + i);
        }
    }

    public void SetActive(bool value)
    {
        BlockImage.SetActive(!value);
    }
}
