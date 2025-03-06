using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaveInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI WaveCountText;

    bool bClick = false;
    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bClick = !bClick;

        if(bClick)
        {

        }
        else
        {
            
        }
    }

}
