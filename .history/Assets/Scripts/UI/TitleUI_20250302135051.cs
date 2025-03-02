using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 5.0f;

    public void StartGame()
    {
         StartCoroutine(GameManager.Instance.LoadSceneAsync("Main Menu"));
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
