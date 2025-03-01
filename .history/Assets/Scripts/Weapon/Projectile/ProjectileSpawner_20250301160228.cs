using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : WeaponBase
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] int ProjectilePoolSize = 5;

    FocusTarget FT;
    bool bRunning = false;

    List<GameObject> ProjectilePools = new List<GameObject>();

    void Awake() 
    {
        FT = GetComponentInParent<FocusTarget>();
    }

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

        StartCoroutine(SpawnProjectile());
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

    IEnumerator SpawnProjectile()
    {
        bRunning = true;

        while(FT.IsEnemyTrigger)
        {
            var PlayerData = GameManager.Instance.CurrentPlayerData;
            int FinalDamage = (int)((WeaponData.WeaponATK + PlayerData.PlayerATK) * PlayerData.PlayerATKCoefficient);

            foreach (var Projectile in ProjectilePools)
            {                
                if(!Projectile.activeInHierarchy)
                {
                    Projectile.transform.position = transform.position;
                    Projectile.transform.rotation = transform.rotation;
                    Projectile.GetComponent<Projectile>().Init(WeaponData.WeaponATK, FT.GetTarget);
                    Projectile.SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(WeaponData.WeaponATKSpeed);
        }

        bRunning = false;
    }

    
}
