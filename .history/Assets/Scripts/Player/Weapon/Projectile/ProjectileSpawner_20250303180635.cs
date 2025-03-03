using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : WeaponBase
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] int ProjectilePoolSize = 5;

    
    

    List<GameObject> ProjectilePools = new List<GameObject>();


    protected override void Start()
    {
        base.Start();

        for(int i = 0; i<ProjectilePoolSize; i++)
        {
            var Projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Projectile.SetActive(false);            
            ProjectilePools.Add(Projectile);
        }
    }

    void Update()
    {
        if(!FT.IsEnemyTrigger || bRunning) return;

        StartCoroutine(StartAttack());
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

    public override void SellWeapon()
    {
        base.SellWeapon();

        foreach (var Projectile in ProjectilePools)
        {
            if(Projectile.activeInHierarchy)
            {
                Projectile.GetComponent<Projectile>().HasDestroy = true;
            }
            else
            {
                Destroy(Projectile);
            }
        }
    }

    IEnumerator StartAttack()
    {
        bRunning = true;

        while(FT.IsEnemyTrigger)
        {
            CalculateDamageInfo();

            SpawnProjectile();

            yield return new WaitForSeconds(FinalATKSpeed);
        }

        bRunning = false;
    }

    void SpawnProjectile()
    {
        foreach (var Projectile in ProjectilePools)
        {
            if (!Projectile.activeInHierarchy)
            {
                Projectile.transform.position = transform.position;
                Projectile.transform.rotation = transform.rotation;
                Projectile.GetComponent<Projectile>().Init(FinalATK, FT.GetTarget);
                Projectile.SetActive(true);
                break;
            }
        }
    }

}
