using UnityEngine;
using UnityEngine.UI;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;

    float OriginWaveTime = 1.0f;
    float WaveTime = 1.0f;
    bool bClickEnabled = true;

    public void UpdateTime(float newWaveTime)
    {
        OriginWaveTime = newWaveTime;
        WaveTime = newWaveTime;
    }

    public void WaveTimeClick()
    {

    }

    void Update()
    {
        if(WaveTime >= 0.0f)
        {
            WaveTime -= Time.deltaTime;
            WaveTimeUI.fillAmount = WaveTime / OriginWaveTime;
        }
        else
        {
            bClickEnabled = false;
        }
    }


}
