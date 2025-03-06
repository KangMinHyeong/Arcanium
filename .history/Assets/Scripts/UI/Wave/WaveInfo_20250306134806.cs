using TMPro;
using UnityEngine;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] TextMeshPro WaveCountText;


    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }
}
