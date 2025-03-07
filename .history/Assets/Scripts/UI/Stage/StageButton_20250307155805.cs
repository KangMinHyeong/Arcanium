using UnityEngine;

public class StageButton : MonoBehaviour
{
    int stageNumber = 0;

    void OnClickStageButton()
    {
        GameManager.Instance.StartStage(stageNumber);
    }
}
