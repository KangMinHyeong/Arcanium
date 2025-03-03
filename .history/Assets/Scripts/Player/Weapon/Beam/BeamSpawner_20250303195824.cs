using UnityEngine;

public class BeamSpawner : WeaponBase
{
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
        // Spawn Effect

        BoxCollider boxCol = Collider as BoxCollider;
        if(!boxCol) return;

        // 빔처럼 한번에 캐스팅
        // int EnemyLayer = 6;
        Collider[] hitColliders = Physics.OverlapBox(transform.parent.position, boxCol.size * 0.5f, transform.rotation);
            
        foreach (Collider col in hitColliders)
        {
            var EnemyHealth = col.GetComponentInParent<Enemy>();
            if(EnemyHealth) EnemyHealth.TakeDamage(FinalATK);
            
            // Debug.Log("감지된 오브젝트: " + col.name);
        }

         Debug.DrawLine(transform.parent.position, transform.parent.position + boxCol.size.z * transform.parent.forward, Color.green, 2f); // ✅ 실행 중 디버깅 가능

        // 아케인볼 같이 이동하는
        // Vector3 direction = transform.forward; // ✅ 전방 방향
        // RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxCol.size * 0.5f, direction, Quaternion.identity, maxDistance, hitLayers);

        // foreach (RaycastHit hit in hits)
        // {
        //         Debug.Log("충돌한 오브젝트: " + hit.collider.name);
        // }
    }

    
}
