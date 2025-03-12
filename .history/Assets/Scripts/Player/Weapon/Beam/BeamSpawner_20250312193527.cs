using UnityEngine;

public class BeamSpawner : WeaponBase
{
    [SerializeField] ParticleSystem ChargingVFX;
    [SerializeField] GameObject LaserVFX;


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
        
        weaponInfo.UpdateWeaponInfo(WeaponData);
        
        return check;
    }

    protected override void ReadyTrigger()
    {
        if(!ChargingVFX.isPlaying) ChargingVFX.Play();
    }

    protected override void AttackTrigger()
    {
        // Spawn Effect
        if(ChargingVFX.isPlaying) ChargingVFX.Stop();
        LaserVFX.SetActive(true);
        Invoke("DeactiveBeam", 1.0f);

        BoxCollider boxCol = Collider as BoxCollider;
        if(!boxCol) return;

        // 빔처럼 한번에 캐스팅
        Collider[] hitColliders = Physics.OverlapBox(boxCol.transform.position + boxCol.center, boxCol.size * 0.5f, transform.localRotation);
        
        foreach (var Enemy in FT.GetEnemies)
        {
            PlayHitVFX(Enemy.transform.position);

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

    void DeactiveBeam()
    {
        LaserVFX.SetActive(false);
    }
    
}
