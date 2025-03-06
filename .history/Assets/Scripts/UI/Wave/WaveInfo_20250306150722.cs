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
        foreach(var AddInfo in AddInfos)
        {
            Destroy(AddInfo);
        }

        int cnt = 1;
        foreach(EnemyWaveData Info in Infos)
        {
            var EnemyData = GameManager.Instance.GetEnemyData(Info.EnemyID);
            int EnemyNumber = Info.EnemyNumber;

            Vector3 Addpos = transform.position + new Vector3(0.0f, -AddInterval * cnt, 0.0f);
            var InfoUI = Instantiate(AddInfoUI, Addpos, Quaternion.identity, EnemyInformation.transform);
            
            InfoUI.GetComponent<EnemyInfoUI>().UpdateEnemyInfo(EnemyData, EnemyNumber);
            AddInfos.Add(InfoUI);

            cnt++;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bClick = !bClick;

        EnemyInformation.SetActive(bClick);
        // if(bClick)
        // {
            
        // }
    }

}
