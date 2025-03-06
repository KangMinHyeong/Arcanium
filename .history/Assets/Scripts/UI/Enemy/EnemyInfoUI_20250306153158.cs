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
        EnemyInformationText.SetActive(true);
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
