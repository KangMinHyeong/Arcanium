using UnityEngine;

public class Fan : WeaponBase
{
    float SlowCoeffecient = 0.75f;
    
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
            SlowCoeffecient = 0.6f;
            break;

        case WeaponState.Level_3:
            SlowCoeffecient = 0.4f;
            break;
        }
        
        weaponInfo.UpdateWeaponInfo(WeaponData);
        
        return check;
    }

    protected override void AttackTrigger()
    {
        // Spawn Effect

        BoxCollider boxCol = Collider as BoxCollider;
        if(!boxCol) return;

        // 빔처럼 한번에 캐스팅
        Collider[] hitColliders = Physics.OverlapBox(boxCol.transform.position + boxCol.center, boxCol.size * 0.5f, transform.localRotation);
        
        foreach (var Enemy in FT.GetEnemies)
        {
            Enemy.SlowMoveSpeed(SlowCoeffecient);
        }
    }

}
