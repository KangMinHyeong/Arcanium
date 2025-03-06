using TMPro;
using UnityEngine;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WeaponName;
    [SerializeField] TextMeshProUGUI WeaponInformation;
    [SerializeField] TextMeshProUGUI WeaponType;
    [SerializeField] TextMeshProUGUI WeaponATK;
    [SerializeField] TextMeshProUGUI WeaponATKSpeed;

    public void UpdateWeaponInfo(WeaponDataStruct WeaponData)
    {
        WeaponName.text = WeaponData.Weaponname;
        WeaponInformation.text = WeaponData.WeaponInformation;
        WeaponType.text = WeaponData.WeaponType;
        WeaponATK.text = WeaponData.WeaponATK;
        WeaponATKSpeed.text = WeaponData.WeaponATKSpeed;
    }
}
