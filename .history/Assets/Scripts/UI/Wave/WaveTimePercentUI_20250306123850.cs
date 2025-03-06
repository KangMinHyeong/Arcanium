using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;
    [SerializeField] GameObject WaveStartUI;

    PlayerController PC;

    float OriginWaveTime = 1.0f;
    float WaveTime = 1.0f;
    bool bClickEnabled = false;
    bool bUpdateTime = false;

    void Start()
    {
        PC = FindAnyObjectByType<PlayerController>();
    }

    public void UpdateTime(float newWaveTime)
    {
        if(newWaveTime < 0.0f) return;

        bClickEnabled = true;
        bUpdateTime = true;
        OriginWaveTime = newWaveTime;
        WaveTime = newWaveTime;
    }

    public void ClickWaveTime()
    {
        if(!bClickEnabled) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Debug.Log("ClickWaveTime");

        if(WaveStartUI.activeInHierarchy)
        {
            WaveStartUI.SetActive(false);
        }
        else
        {
            WaveStartUI.SetActive(true);
            PC.CloseLastClickUI(WaveStartUI);
        } 
    }

    void Update()
    {
        if(bUpdateTime) UpdateTimePercent();
    }

    void UpdateTimePercent()
    {        
        if(WaveTime >= 0.0f)
        {
            WaveTime -= Time.deltaTime;
            WaveTimeUI.fillAmount = WaveTime / OriginWaveTime;
        }
        else
        {
            WaveTimeUI.fillAmount = 0.0f;
            bClickEnabled = false;
            bUpdateTime = false;
        }
    }
}
