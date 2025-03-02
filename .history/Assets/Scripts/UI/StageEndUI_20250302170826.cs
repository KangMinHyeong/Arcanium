using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndUI : MonoBehaviour
{
    public void GoMainMenu()
    {
        GameManager.Instance.StartLoadScene("Main Menu");
    }

    public void RestartStage()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.StartStageScene();
    }

    public void StartNextStage()
    {
        GameManager.Instance.StartStageScene();
    }
}
