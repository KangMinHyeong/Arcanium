using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class WaveInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI WaveCountText;
    [SerializeField] GameObject EnemyInformation;
    [SerializeField] GameObject AddInfoUI;

    bool bClick = false;

    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }

    public void UpdateWaveInfo(List<EnemyWaveData> Infos)
    {
        foreach(EnemyWaveData Info in Infos)
        {
            var EnemyData = GetEnemyData(GetEnemyData);
            Debug.Log("Info.EnemyID : " + Info.EnemyID);
            Debug.Log("Info.EnemyNumber : " + Info.EnemyNumber);
        }
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
