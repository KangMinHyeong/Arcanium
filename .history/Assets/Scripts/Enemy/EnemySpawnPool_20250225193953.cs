using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float SpawnRate = 2.0f;
    [SerializeField] int PoolSize = 8;
    [SerializeField] int TotalEnemyNumber = 50;

    List<GameObject> EnemyPools = new List<GameObject>();

    void Start()
    {
        SetEnemyPools();
        StartCoroutine(SpwanEnemy());
    }

    void SetEnemyPools()
    {
        for(int i = 0; i<PoolSize; i++)
        {
            var Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            Enemy.SetActive(false);
            EnemyPools.Add(Enemy);
        }
    }

    IEnumerator SpwanEnemy()
    {
        while(TotalEnemyNumber > 0)
        {
            foreach(var Enemy in EnemyPools)
            {
                if(!Enemy.activeInHierarchy)
                {
                    Enemy.SetActive(true);
                    TotalEnemyNumber--;
                    break;
                }
            }
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
