using TMPro;
using UnityEngine;

public class WaveInfo : MonoBehaviour
{
    TextMeshPro WaveCountText;
    int RemainWaveCount;


    public void UpdateWaveCount(int RemainWaveCount)
    {
        this.RemainWaveCount = RemainWaveCount;
    }
}
