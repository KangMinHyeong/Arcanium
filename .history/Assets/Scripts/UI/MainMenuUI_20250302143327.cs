using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartStage()
    {
        GameManager.Instance.StartStageScene();
    }

    public void Enhance_ATK()
    {
        Debug.Log("Enhance_ATK");
    }

    public void Enhance_ATKSpeed()
    {
        Debug.Log("Enhance_ATKSpeed");
    }
}
