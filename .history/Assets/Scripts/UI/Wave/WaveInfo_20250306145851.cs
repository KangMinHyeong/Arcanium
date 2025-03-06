using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class WaveInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI WaveCountText;
    [SerializeField] GameObject EnemyInformation;
    [SerializeField] GameObject AddInfoUI;
    [SerializeField] float AddInterval = 100.0f;

    bool bClick = false;

    public void UpdateWaveCount(int RemainWaveCount)
    {
        WaveCountText.text = RemainWaveCount.ToString();
    }

    public void UpdateWaveInfo(List<EnemyWaveData> Infos)
    {
        foreach(EnemyWaveData Info in Infos)
        {
            var EnemyData = GameManager.Instance.GetEnemyData(Info.EnemyID);
            int EnemyNumber = Info.EnemyNumber;

            // var InfoUI = Instantiate(AddInfoUI, );
            // Debug.Log("Info.EnemyID : " + Info.EnemyID);
            // Debug.Log("Info.EnemyNumber : " + Info.EnemyNumber);
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
