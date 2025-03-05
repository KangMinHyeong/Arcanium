using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndUI : MonoBehaviour
{
    public void BackToGame()
    {
        gameObject.SetActive(false);
        FindAnyObjectByType<PlayerController>().BlockClick(false);
        Time.timeScale = 1.0f;
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
