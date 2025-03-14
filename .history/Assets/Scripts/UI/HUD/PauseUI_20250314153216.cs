using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject PauseUIObj;
    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();    
    }

    public void OnClickPauseUI()
    {
        Time.timeScale = 0.0f;

        PC.BlockClick(true);
        PauseUIObj.SetActive(true);
    }
}
