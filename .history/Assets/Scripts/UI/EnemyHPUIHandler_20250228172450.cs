using UnityEngine.UI;
using UnityEngine;

public class EnemyHPUIHandler : MonoBehaviour
{
    [SerializeField] Image HPImage;
    [SerializeField] float barSpeed = 3.0f;
    float TargetHP = 1.0f;


    public void Init()
    {
        TargetHP = 1.0f;
    }

    public void UpdateHP(float ratio)
    {
        TargetHP = ratio;
    }

    void Update()
    {
        HPImage.fillAmount = Mathf.MoveTowards(HPImage.fillAmount, TargetHP, )
    }
}
