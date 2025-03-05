using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndUI : MonoBehaviour
{
    [SerializeField] GameObject BackMenu;

    public void BackToGame()
    {
        BackMenu.SetActive(false);
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
