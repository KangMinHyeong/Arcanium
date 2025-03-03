using UnityEngine;

public class BeamSpawner : WeaponBase
{
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

    protected override void Attack()
    {
        // Spawn Effect

        // 아케인볼 같이 이동하는
        Vector3 direction = transform.forward; // ✅ 전방 방향
            RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxSize / 2, direction, Quaternion.identity, maxDistance, hitLayers);

            foreach (RaycastHit hit in hits)
            {
                Debug.Log("충돌한 오브젝트: " + hit.collider.name);
            }

        // 빔처럼 한번에 캐스팅

    }
}
