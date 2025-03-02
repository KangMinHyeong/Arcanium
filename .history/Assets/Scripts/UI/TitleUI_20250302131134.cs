using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); // ✅ "GameScene"으로 이동
    }
}
