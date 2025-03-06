using UnityEngine.UI;
using UnityEngine;

public class EnemyHPUIHandler : MonoBehaviour
{
    [SerializeField] GameObject HPUI;
    [SerializeField] Image HPImage;
    [SerializeField] float barSpeed = 3.0f;

    float TargetHP = 1.0f;
    bool bActive = false;

    public bool Active {get {return bActive;}}

    void OnEnable()
    {
        TargetHP = 1.0f;
        HPImage.fillAmount = 1.0f;
    }

    public void SetActive()
    {
        bActive = true;
        HPUI.SetActive(bActive);
    }

    public void UpdateHP(float ratio)
    {
        TargetHP = ratio;
    }

    void Update()
    {
        HPImage.fillAmount = Mathf.MoveTowards(HPImage.fillAmount, TargetHP, barSpeed * Time.deltaTime);
    }
}
