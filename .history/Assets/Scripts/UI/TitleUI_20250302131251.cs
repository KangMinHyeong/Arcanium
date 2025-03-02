using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Menu"); // "Main Menu"으로 이동
    }

    public void QuitGame()
    {
        //SceneManager.LoadScene("Main Menu"); // "Main Menu"으로 이동
    }
}
