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

    List<GameObject> AddInfos = new List<GameObject>();
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

            Vector3 Addpos = transform.position + new Vector3(0.0f, -AddInterval, 0.0f);
            var InfoUI = Instantiate(AddInfoUI, Addpos, Quaternion.identity, EnemyInformation.transform);
            
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
