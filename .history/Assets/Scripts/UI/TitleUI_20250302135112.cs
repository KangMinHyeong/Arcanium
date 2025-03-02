using System.Collections;
using UnityEngine;


public class TitleUI : MonoBehaviour
{
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
