using UnityEngine;
using UnityEngine.UI;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;

    float OriginWaveTime = 1.0f;
    float WaveTime = 1.0f;
    float TimePercent = 1.0f;

    public void UpdateTime(float newWaveTime)
    {
        WaveTime = newWaveTime;
    }

    void Update()
    {
        WaveTime -= Time.deltaTime;
        WaveTimeUI.fillAmount = TimePercent;
    }
}
