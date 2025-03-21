using UnityEngine;

public class StageButton : MonoBehaviour
{
    [SerializeField] GameObject StageLockImage;
    public int stageNumber = 0;

    bool bLock = false;

    public void OnClickStageButton()
    {
        if(bLock) return;

        GameManager.Instance.StartStage(stageNumber);
    }

    public void OnLockStageButton()
    {
        StageLockImage.SetActive(true);
        bLock = true;
    }
    
}
