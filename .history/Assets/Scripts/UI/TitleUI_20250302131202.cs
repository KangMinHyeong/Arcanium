using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main Menu"); // ✅ "GameScene"으로 이동
    }
}
