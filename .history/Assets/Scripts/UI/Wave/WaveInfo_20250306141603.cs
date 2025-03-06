using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaveInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI WaveCountText;
    [SerializeField] GameObject EnemyInformation;

    bool bClick = false;
    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bClick = !bClick;

        EnemyInformation.SetActive(bClick);
        if(bClick)
        {
            
        }
    }

}
