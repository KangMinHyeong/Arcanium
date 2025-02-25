using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] int PoolSize = 8;

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
        yield return null;
    }
}
