using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] int ProjectilePoolSize = 5;
    [SerializeField] int DamageAmount = 20;
    [SerializeField] float SpwanRate = 1.0f;
    [SerializeField] string CollisionEnableTag = "";

    FocusTarget FT;
    bool bRunning = false;

    List<GameObject> ProjectilePools = new List<GameObject>();

    void Awake() 
    {
        FT = GetComponent<FocusTarget>();
    }

    void Start()
    {
        for(int i = 0; i<ProjectilePoolSize; i++)
        {
            var Projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            ProjectilePrefab.GetComponent<Projectile>().Init(DamageAmount, CollisionEnableTag);
            ProjectilePrefab.SetActive(false);
            ProjectilePools.Add(ProjectilePrefab);
        }
    }

    void Update()
    {
        if(!FT.IsEnemyTrigger || bRunning) return;

        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile()
    {
        while(FT.IsEnemyTrigger)
        {
            foreach (var Projectile in ProjectilePools)
            {
                if(!Projectile.activeInHierarchy)
                {
                    Projectile.SetActive(true);
                    break;
                }
            }

            yield return new WaitForSeconds(SpwanRate);
        }
    }
}
