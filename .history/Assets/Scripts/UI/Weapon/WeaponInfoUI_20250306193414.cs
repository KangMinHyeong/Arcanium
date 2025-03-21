using TMPro;
using UnityEngine;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WeaponName;
    [SerializeField] TextMeshProUGUI WeaponInformation;
    [SerializeField] TextMeshProUGUI WeaponType;
    [SerializeField] TextMeshProUGUI WeaponATK;
    [SerializeField] TextMeshProUGUI WeaponATKSpeed;
    [SerializeField] TextMeshProUGUI WeaponCost;

    public void UpdateWeaponInfo(WeaponDataStruct WeaponData)
    {
        WeaponName.text = WeaponData.Weaponname;
        WeaponInformation.text = WeaponData.WeaponInformation;
        WeaponType.text = WeaponData.WeaponType;
        WeaponATK.text = "ATK : " + WeaponData.WeaponATK.ToString();
        WeaponATKSpeed.text = "ATKSpeed : " + WeaponData.WeaponATKSpeed.ToString("F2");
        WeaponCost.text = "Cost : " + WeaponData.WeaponATKSpeed.ToString("F2");
    }
}
