using UnityEngine;
using System.Collections;
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
    protected FocusTarget FT;

    protected WeaponDataStruct WeaponData;
    protected WayPoint CurrentWayPoint;
    protected Collider Collider;

    protected WeaponState weaponState = WeaponState.Level_1;
    protected int FinalATK;
    protected float FinalATKSpeed;
    protected float Range;
    protected bool bRunning = false;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        Collider = GetComponentInParent<Collider>();
        FT = GetComponentInParent<FocusTarget>();

        InitWeaponData();
    }

    void Update()
    {
        if(!FT.IsEnemyTrigger || bRunning) return;

        StartCoroutine(StartAttack());
    }

    void InitWeaponData()
    {
        WeaponData = GameManager.Instance.GetWeaponData[WeaponID];
        FT.IsRotate = WeaponData.WeaponRotation;
        
        UpdateWeaponRange();
    }

    void UpdateWeaponRange()
    {
        SphereCollider sphereCol = Collider as SphereCollider;
        if(sphereCol)
        {
            WeaponUI.GetComponentInChildren<WeaponRange>().SetRange_Circle(WeaponData.WeaponRange); 
            sphereCol.radius = WeaponData.WeaponRange;
            return;
        }

        BoxCollider boxCol = Collider as BoxCollider;
        if(boxCol)
        {
            Vector3 newsize = boxCol.size;
            newsize.z = WeaponData.WeaponRange;

            Vector3 newcenter = newsize * 0.5f;
            newcenter.x = 0.0f;

            boxCol.size = newsize;
            boxCol.center = newcenter;

            WeaponUI.GetComponentInChildren<WeaponRange>().SetRange_Circle(WeaponData.WeaponRange); 
            return;
        }
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

    IEnumerator StartAttack()
    {
        bRunning = true;

        while(FT.IsEnemyTrigger)
        {
            CalculateDamageInfo();
            AttackTrigger();

            yield return new WaitForSeconds(FinalATKSpeed);
        }

        bRunning = false;
    }
    
    protected virtual void AttackTrigger()
    {
    }
}
