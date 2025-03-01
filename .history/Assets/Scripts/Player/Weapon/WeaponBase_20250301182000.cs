using UnityEngine;
using System.Collections.Generic;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] GameObject WeaponUI;
    [SerializeField] int WeaponID;

    protected PlayerController PC;
    protected WeaponDataStruct WeaponData;
    protected WayPoint CurrentWayPoint;
    protected SphereCollider Collider;

    protected int FinalATK;
    protected float FinalATKSpeed;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        Collider = GetComponentInChildren<SphereCollider>();

        InitWeaponData();
    }

    void InitWeaponData()
    {
        WeaponData = GameManager.Instance.GetWeaponData[WeaponID];       
    }

    public void SetWayPoint(WayPoint wayPoint)
    {
        CurrentWayPoint = wayPoint;
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

    public virtual void SellWeapon()
    {
        PC.UpdateGold(WeaponData.Cost / 2);
        CurrentWayPoint.InitPlacable();

        Destroy(transform.root.gameObject);
    }

    protected void CalculateDamageInfo()
    {
        var PlayerData = GameManager.Instance.CurrentPlayerData;
        FinalATK = (int)((WeaponData.WeaponATK + PlayerData.PlayerATK) * PlayerData.PlayerATKCoefficient);
        FinalATKSpeed = WeaponData.WeaponATKSpeed / PlayerData.PlayerATKSpeed;
    }
    
}
