using UnityEngine;

public class Fan : WeaponBase
{
    protected override void AttackTrigger()
    {
        // Spawn Effect

        BoxCollider boxCol = Collider as BoxCollider;
        if(!boxCol) return;

        // 빔처럼 한번에 캐스팅
        Collider[] hitColliders = Physics.OverlapBox(boxCol.transform.position + boxCol.center, boxCol.size * 0.5f, transform.localRotation);
        
        foreach (var Enemy in FT.GetEnemies)
        {
            var EnemyHealth = Enemy.GetComponent<Enemy>();
            if(EnemyHealth) EnemyHealth.TakeDamage(FinalATK);
        }


        // Debug.DrawLine(transform.parent.position, transform.parent.position + boxCol.size.z * transform.parent.forward, Color.red, 2f); // ✅ 실행 중 디버깅 가능

        // 아케인볼 같이 이동하는
        // Vector3 direction = transform.forward; // ✅ 전방 방향
        // RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxCol.size * 0.5f, direction, Quaternion.identity, maxDistance, hitLayers);

        // foreach (RaycastHit hit in hits)
        // {
        //         Debug.Log("충돌한 오브젝트: " + hit.collider.name);
        // }
    }
}
