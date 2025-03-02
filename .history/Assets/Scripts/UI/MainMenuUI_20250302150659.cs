using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartStage()
    {
        GameManager.Instance.StartStageScene();
    }

    public void Enhance_ATK()
    {
        GameManager.Instance.UpgradeATK_Add(10);
    }

    public void Enhance_ATKSpeed()
    {
        GameManager.Instance.UpgradeATKSpeed(2.0f);
    }
}
