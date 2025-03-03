using UnityEngine;

public class BeamSpawner : WeaponBase
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;

        var EnemyMover = other.GetComponentInParent<EnemyMover>();
        if(!EnemyMover || Enemies.Contains(EnemyMover)) return;

        bEnemyTrigger = true;
        Enemies.Add(EnemyMover);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != Enemytag) return;

        var EnemyMover = other.GetComponentInParent<EnemyMover>();
        if(EnemyMover) Enemies.Remove(EnemyMover);
    }
    
    public override bool EnhanceWeapon()
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
}
