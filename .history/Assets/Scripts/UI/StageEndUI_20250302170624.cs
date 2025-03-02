using UnityEngine;

public class StageEndUI : MonoBehaviour
{
    public void GoMainMenu()
    {
        GameManager.Instance.StartLoadScene("Main Menu");
    }

    public void RestartStage()
    {
        GameManager.Instance.StartStageScene();
    }

    public void StartNextStage()
    {
        GameManager.Instance.StartStageScene();
    }
}
