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
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void UpdateEnemyInfo(EnemyData enemyData, int enemyNum)
    {
        this.enemyData = enemyData;
        EnemyNumText.text = enemyNum.ToString();
    }
}
