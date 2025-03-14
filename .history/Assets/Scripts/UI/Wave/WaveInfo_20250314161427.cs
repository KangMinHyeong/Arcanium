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

    public void OnPointerClick(PointerEventData eventData) 
    {
        // 클릭 시 다음 웨이브의 Enemy 정보를 보여주는 UI 활성화
        bClick = !bClick;

        EnemyInformation.SetActive(bClick);
    }

    public void UpdateWaveCount(int RemainWaveCount)
    {
        // 남은 웨이브 수를 업데이트
        WaveCountText.text = RemainWaveCount.ToString();
    }

    public void UpdateWaveInfo(List<EnemyWaveData> Infos)
    {
        // 다음 웨이브 시작 시 이전 Enemy Info UI 삭제
        foreach(var AddInfo in AddInfos)
        {
            Destroy(AddInfo);
        }

        // 다음 웨이브의 Enemy Data를 읽고, 해당하는 Enemy들로 EnemyInfo UI 생성
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

    

}
