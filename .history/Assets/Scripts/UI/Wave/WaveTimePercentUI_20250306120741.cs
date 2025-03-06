using UnityEngine;
using UnityEngine.UI;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;

    float OriginWaveTime = 1.0f;
    float WaveTime = 1.0f;

    public void UpdateTime(float newWaveTime)
    {
        OriginWaveTime = newWaveTime;
        WaveTime = newWaveTime;
    }

    void Update()
    {
        if(WaveTime >= 0.0f)
        {
            WaveTime -= Time.deltaTime;
            WaveTimeUI.fillAmount = WaveTime / OriginWaveTime;
        }
    }
}
