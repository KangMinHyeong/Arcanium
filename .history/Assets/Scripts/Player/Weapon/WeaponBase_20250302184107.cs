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
        Collider = GetComponentInParent<SphereCollider>();

        InitWeaponData();
    }

    void InitWeaponData()
    {
        WeaponData = GameManager.Instance.GetWeaponData[WeaponID];

        UpdateWeaponData();
    }

    void UpdateWeaponData()
    {
        WeaponUI.GetComponentInChildren<WeaponRange>().SetRange(WeaponData.WeaponRange);
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

    public void CheckEnhancableWeapon()
    {
        EnhanceWeapon();
    }

    public virtual bool EnhanceWeapon()
    {
        if(weaponState == WeaponState.Level_3) 
        {
            PC.DisplayEnhanceCompleteUI();
            // To Do : 강화를 모두 완료했습니다 UI
            return false;
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
            PC.DisplayRequireGoldUI();
            return false;
        }

        PC.UpdateGold(-requireCost);
        weaponState = (WeaponState)((int)weaponState + 1);

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
