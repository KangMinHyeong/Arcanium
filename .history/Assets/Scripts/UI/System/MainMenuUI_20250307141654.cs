using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject StageSelectUI;

    public void StartStage()
    {
        StageSelectUI.SetActive(true);
        // GameManager.Instance.StartLastStage();
    }

    public void Enhance_ATK()
    {
        // GameManager.Instance.UpgradeATK_Add(10);
    }

    public void Enhance_ATKSpeed()
    {
        // GameManager.Instance.UpgradeATKSpeed(2.0f);
    }
}
