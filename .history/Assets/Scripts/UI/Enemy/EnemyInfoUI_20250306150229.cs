using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoUI : MonoBehaviour
{
    [SerializeField] Image EnemyImage;
    [SerializeField] TextMeshProUGUI EnemyNumText;

    public void UpdateEnemyInfo(EnemyData enemyData, int enemyNum)
    {

        EnemyNumText.text = enemyNum.ToString();
    }
}
