using UnityEngine;
using System.Collections.Generic;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] GameObject WeaponUI;
    [SerializeField] int WeaponID;

    protected PlayerController PC;
    protected WeaponDataStruct WeaponData;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        InitWeaponData();
    }

    void InitWeaponData()
    {
        WeaponData = PC.GetWeaponData[WeaponID];       
    }

    public void OpenWeaponUI()
    {
        PC.CloseLastClickUI(WeaponUI);
        WeaponUI.SetActive(true);
    }

    public void EnhanceWeapon()
    {
        Debug.Log("EnhanceWeapon");
    }

    public void SellWeapon()
    {
        Debug.Log("SellWeapon");
        PC.UpdateGold(WeaponData.Cost / 2);
        gameObject.SetActive(false); //Destroy(gameObject);
    }
}
