using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : WeaponBase
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] int ProjectilePoolSize = 5;
    [SerializeField] int DamageAmount = 20;
    [SerializeField] float SpwanRate = 1.0f;


    FocusTarget FT;
    bool bRunning = false;

    List<GameObject> ProjectilePools = new List<GameObject>();

    void Awake() 
    {
        FT = GetComponentInParent<FocusTarget>();
    }

    void Start()
    {
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

    IEnumerator SpawnProjectile()
    {
        bRunning = true;

        while(FT.IsEnemyTrigger)
        {
            foreach (var Projectile in ProjectilePools)
            {
                if(!Projectile.activeInHierarchy)
                {
                    Projectile.transform.position = transform.position;
                    Projectile.transform.rotation = transform.rotation;
                    Projectile.GetComponent<Projectile>().Init(DamageAmount, FT.GetTarget);
                    Projectile.SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(SpwanRate);
        }

        bRunning = false;
    }
}
