using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 5.0f;

    public void StartGame()
    {
        GameManager.Instance.ActiveLoadingUI(true);
        SceneManager.LoadScene("GameScene"); // ✅ "GameScene"으로 이동
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
