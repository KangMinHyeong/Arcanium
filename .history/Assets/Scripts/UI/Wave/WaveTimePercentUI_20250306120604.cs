using UnityEngine;
using UnityEngine.UI;

public class WaveTimePercentUI : MonoBehaviour
{
    [SerializeField] Image WaveTimeUI;

    float WaveTime;
    float TimePercent = 1.0f;

    public void UpdateTime(float newWaveTime)
    {
        WaveTime = newWaveTime;
    }

    void Update()
    {
        WaveTimeUI.fillAmount = TimePercent;
    }
}
