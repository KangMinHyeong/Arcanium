using UnityEngine;

public class PauseUI : MonoBehaviour
{
    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();    
    }

    public void OnClickPauseUI()
    {
        Time.timeScale = 0.0f;

        PC
        // Spawn Pause Menu
    }

    void EndPause()
    {

    }
}
