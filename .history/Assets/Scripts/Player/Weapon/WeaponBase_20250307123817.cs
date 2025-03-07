using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using TMPro;

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
    [SerializeField] float FirstDelay = 0.0f;

    [SerializeField] GameObject ModelRoot;
    [SerializeField] GameObject Active_Level2_Obj;
    [SerializeField] GameObject Active_Level3_Obj;
    [SerializeField] GameObject Deactive_Level2_Obj;
    [SerializeField] GameObject Deactive_Level3_Obj;

    [SerializeField] protected WeaponInfoUI weaponInfo;
    [SerializeField] protected TextMeshProUGUI SellCostText;
    [SerializeField] protected TextMeshProUGUI EnhanceCostText;

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
    protected int SellCost;

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

        weaponInfo.UpdateWeaponInfo(WeaponData);
        UpdateSellCost();
        UpdateEnhanceCost();
    }

    void UpdateWeaponRange()
    {
        WeaponUI.GetComponentInChildren<WeaponRange>().SetRange(WeaponData.WeaponRotation, WeaponData.WeaponRange); 

        SphereCollider sphereCol = Collider as SphereCollider;
        if(sphereCol)
        {
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

    void UpdateSellCost()
    {
        SellCost = WeaponData.Cost / 2; 

        switch (weaponState)
        {
            case WeaponState.Level_2:
                if(Active_Level2_Obj) {Active_Level2_Obj.SetActive(true);}
                if(Deactive_Level2_Obj) {Deactive_Level2_Obj.SetActive(false);}
                ModelRoot.transform.localScale *= 1.2f;
                break;
            
            case WeaponState.Level_3:
                if(Active_Level3_Obj) {Active_Level3_Obj.SetActive(true);}
                if(Deactive_Level3_Obj) {Deactive_Level3_Obj.SetActive(false);}
                ModelRoot.transform.localScale *= 1.3f;
                break;
        }
        
        SellCostText.text = SellCost.ToString();
    }

    void UpdateEnhanceCost()
    {

    }

    protected virtual bool EnhanceWeapon()
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

        GameManager.Instance.PlayEnhanceVFX(transform.root.position);

        PC.UpdateGold(-requireCost);
        weaponState = (WeaponState)((int)weaponState + 1);

        SwitchWeaponModel();

        return true;
    }

    protected void SwitchWeaponModel()
    {
        switch (weaponState)
        {
            case WeaponState.Level_2:
                if(Active_Level2_Obj) {Active_Level2_Obj.SetActive(true);}
                if(Deactive_Level2_Obj) {Deactive_Level2_Obj.SetActive(false);}
                ModelRoot.transform.localScale *= 1.2f;
                break;
            
            case WeaponState.Level_3:
                if(Active_Level3_Obj) {Active_Level3_Obj.SetActive(true);}
                if(Deactive_Level3_Obj) {Deactive_Level3_Obj.SetActive(false);}
                ModelRoot.transform.localScale *= 1.3f;
                break;
        }
    }

    public virtual void SellWeapon()
    {
        PC.UpdateGold(SellCost);
        CurrentWayPoint.InitPlacable();

        Destroy(transform.root.gameObject);
    }

    public void RotateWeapon()
    {
        transform.root.rotation = Quaternion.Euler(0, transform.root.eulerAngles.y + 90.0f, 0);
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
            yield return new WaitForSeconds(FirstDelay);

            AttackTrigger();

            yield return new WaitForSeconds(FinalATKSpeed);
        }

        bRunning = false;
    }
    
    protected virtual void AttackTrigger()
    {
    }
}
