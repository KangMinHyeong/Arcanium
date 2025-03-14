using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyInfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image EnemyImage;
    [SerializeField] TextMeshProUGUI EnemyNumText;
    [SerializeField] GameObject EnemyInformationText;

    EnemyData enemyData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스 포인터 오버랩 시 Enemy 세부 정보 표시 활성화
        EnemyInformationText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스 포인터 오버랩 종료 시 Enemy 세부 정보 표시 비활성화
        EnemyInformationText.SetActive(false);
    }
    
    public void UpdateEnemyInfo(EnemyData enemyData, int enemyNum)
    {
        // Enemy Data로 텍스트 업데이트 및 Enemy 수 표시시
        this.enemyData = enemyData;

        EnemyInformationText.GetComponentInChildren<TextMeshProUGUI>().text = enemyData.EnemyInformation;
        EnemyNumText.text = enemyNum.ToString();

        var sprite = Resources.Load<Sprite>(enemyData.EnemyImagePath);
        EnemyImage.sprite = sprite;
    }
}
