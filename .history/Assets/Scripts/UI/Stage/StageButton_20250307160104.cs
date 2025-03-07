using UnityEngine;

public class StageButton : MonoBehaviour
{
    [SerializeField] GameObject StageLockImage;
    public int stageNumber = 0;

    public void OnClickStageButton()
    {
        GameManager.Instance.StartStage(stageNumber);
    }

    public void OnLockStageButton()
    {
        GameManager.Instance.StartStage(stageNumber);
    }
    
}
