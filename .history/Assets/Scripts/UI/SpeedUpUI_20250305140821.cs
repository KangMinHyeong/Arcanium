using UnityEngine;

public class SpeedUpUI : MonoBehaviour
{
    int SpeedUpCount = 0;

    public void OnClickPauseUI()
    {
        switch(SpeedUpCount)
        {
        case 0:
            {
                
                SpeedUpCount++;
                break;
            }

        case 1:
            {
                SpeedUpCount++;
                GameManager.Instance.stageTimeScale = 3.0f;
                break;
            }

        case 2:
            {
                SpeedUpCount = 0;
                GameManager.Instance.stageTimeScale = 1.0f;
                break;
            }
        }

        Time.timeScale = GameManager.Instance.stageTimeScale;
        // Spawn Pause Menu
    }
}
