using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndUI : MonoBehaviour
{
    public void RestartStage()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.StartLoadScene(CurrentSceneIndex);
    }
    
    public void GoMainMenu()
    {
        GameManager.Instance.StartLoadScene("Main Menu");
    }

    public void RestartStage()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.StartLoadScene(CurrentSceneIndex);
    }

    // public void StartNextStage()
    // {
    //     GameManager.Instance.StartStageScene();
    // }
}
