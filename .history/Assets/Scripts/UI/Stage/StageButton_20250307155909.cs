using UnityEngine;

public class StageButton : MonoBehaviour
{
    int stageNumber = 0;

    public void OnClickStageButton()
    {
        GameManager.Instance.StartStage(stageNumber);
    }
}
