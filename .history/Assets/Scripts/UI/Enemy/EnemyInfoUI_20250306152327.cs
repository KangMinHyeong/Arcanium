using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyInfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image EnemyImage;
    [SerializeField] TextMeshProUGUI EnemyNumText;

    EnemyData enemyData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEnemyInfo(EnemyData enemyData, int enemyNum)
    {
        this.enemyData = enemyData;
        EnemyNumText.text = enemyNum.ToString();
    }
}
