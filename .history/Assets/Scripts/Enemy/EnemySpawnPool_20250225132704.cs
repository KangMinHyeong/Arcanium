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

    }

    IEnumerator SpwanEnemy()
    {
        
    }
}
