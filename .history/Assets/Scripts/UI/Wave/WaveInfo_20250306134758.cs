using TMPro;
using UnityEngine;

public class WaveInfo : MonoBehaviour
{
    TextMeshPro WaveCountText;


    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }
}
