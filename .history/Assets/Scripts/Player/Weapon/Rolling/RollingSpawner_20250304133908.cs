using UnityEngine;

public class RollingSpawner : WeaponBase
{
    [SerializeField] int RollingNumber = 3;

    GameObject Rollings;

    protected override void Start()
    {
        base.Start();

        bRunning = false;
        SpwanRolling(RollingNumber);
    }

    void SpwanRolling(int SpawnNum)
    {
        if(Rollings) Destroy(Rollings);


    }

    protected override bool EnhanceWeapon()
    {
        bool check = base.EnhanceWeapon();
        if(!check) return false;

        // To Do : 강화 적용 (외형 및 능력치)
        switch (weaponState)
        {
        case WeaponState.Level_1:
            break;

        case WeaponState.Level_2:
            WeaponData.WeaponATK += 5;
            break;

        case WeaponState.Level_3:
            WeaponData.WeaponATK += 15;
            break;
        }
        
        return check;
    }

    protected override void AttackTrigger()
    {
        Debug.Log("AttackTrigger");
    }
}
