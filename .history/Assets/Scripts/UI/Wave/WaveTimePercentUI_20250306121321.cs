using UnityEngine;
using UnityEngine.UI;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;

    float OriginWaveTime = 1.0f;
    float WaveTime = 1.0f;
    bool bClickEnabled = true;
    bool bUpdateTime = false;

    public void UpdateTime(float newWaveTime)
    {
        bUpdateTime = true;
        OriginWaveTime = newWaveTime;
        WaveTime = newWaveTime;
    }

    public void WaveTimeClick()
    {

    }

    void Update()
    {
        UpdateTimePercent();
    }

    void UpdateTimePercent()
    {
        if(!bUpdateTime) return;
        
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
