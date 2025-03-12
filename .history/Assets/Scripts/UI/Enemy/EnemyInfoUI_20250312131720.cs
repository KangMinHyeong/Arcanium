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
        EnemyInformationText.SetActive(false);
    }

    public void UpdateEnemyInfo(EnemyData enemyData, int enemyNum)
    {
        this.enemyData = enemyData;

        EnemyInformationText.GetComponentInChildren<TextMeshProUGUI>().text = enemyData.EnemyInformation;
        EnemyNumText.text = enemyNum.ToString();

        var EnemyPrefab = Resources.Load<GameObject>(enemyData.EnemyImagePath);
        EnemyImage.
    }
}
