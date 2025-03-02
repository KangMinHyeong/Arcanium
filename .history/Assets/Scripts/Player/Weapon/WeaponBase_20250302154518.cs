using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;

public enum WeaponState
{
    Level_1 = 1,
    Level_2 = 2,
    Level_3 = 3,
}

public class WeaponBase : MonoBehaviour
{
    [SerializeField] GameObject WeaponUI;
    [SerializeField] int WeaponID;

    protected PlayerController PC;
    protected WeaponDataStruct WeaponData;
    protected WayPoint CurrentWayPoint;
    protected SphereCollider Collider;

    protected WeaponState weaponState = WeaponState.Level_1;
    protected int FinalATK;
    protected float FinalATKSpeed;
    protected float Range;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();

        InitWeaponData();
    }

    void InitWeaponData()
    {
        Collider = GetComponentInParent<SphereCollider>();

        WeaponData = GameManager.Instance.GetWeaponData[WeaponID];     

        Collider.radius = WeaponData.WeaponRange;
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

    public virtual void EnhanceWeapon()
    {
        if(weaponState == WeaponState.Level_3) 
        {
            // To Do : 강화를 모두 완료했습니다 UI
            return;
        }

        int requireCost = 0;
        switch (weaponState)
        {
            case WeaponState.Level_1:
                requireCost = WeaponData.EnhanceCostLevel_2;
                break;
            
            case WeaponState.Level_2:
                requireCost = WeaponData.EnhanceCostLevel_3;
                break;
        }

        if(requireCost > PC.stageGold)
        {
            // To Do : 골드가 부족합니다 UI
            return;
        }

        PC.UpdateGold(-requireCost);
        weaponState = (WeaponState)((int)weaponState + 1);

        switch (weaponState)
        {
            case WeaponState.Level_1:
                Debug.Log("upgrade : Level_1");
                break;
            
            case WeaponState.Level_2:
                Debug.Log("upgrade : Level_2");
                break;

            case WeaponState.Level_3:
                Debug.Log("upgrade : Level_3");
                break;
        }

        return true;
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
        FinalATKSpeed = 1.0f / (WeaponData.WeaponATKSpeed * PlayerData.PlayerATKSpeed);
    }
    
}
