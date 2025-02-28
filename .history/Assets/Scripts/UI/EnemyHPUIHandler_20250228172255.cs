using UnityEngine.UI;
using UnityEngine;

public class EnemyHPUIHandler : MonoBehaviour
{
    Image HPImage;

    int MaxHP;
    int CurrentHP;

    float TargetHP = 1.0f;

    public void Init(int MaxHP)
    {
        TargetHP = 1.0f;
    }

    public void UpdateHP()
    {
        TargetHP
    }

    void Update()
    {
        HPImage.fillAmount = Mathf.MoveTowards(HPImage.fillAmount, TargetHP, )
    }
}
