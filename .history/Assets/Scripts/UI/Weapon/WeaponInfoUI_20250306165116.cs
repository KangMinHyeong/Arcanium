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
        WeaponName.text = 
        WeaponInformation.text = 
        WeaponType.text = 
        WeaponATK.text = 
        WeaponName.text = 
    }
}
