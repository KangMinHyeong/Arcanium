using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 5.0f;

    public void StartGame()
    {
         StartCoroutine(LoadSceneAsync("Main Menu"));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            Debug.Log($"Loading Progress: {operation.progress * 100}%"); // ✅ 로딩 퍼센트 출력
            yield return null;
        }

        float CurrentMoveTime = 0.0f;
        while(CurrentMoveTime < TargetMoveTime)
        {
            CurrentMoveTime += Time.deltaTime;
            Debug.Log($"Loading Progress: " + CurrentMoveTime); // ✅ 로딩 퍼센트 출력
            yield return new WaitForEndOfFrame();
        }
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
