using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] float SpwanRate = 1.0f;

    FocusTarget FT;
    bool bRunning = false;

    void Awake() 
    {
        FT = GetComponent<FocusTarget>();
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
            
            yield return new WaitForSeconds(SpwanRate);
        }
    }
}
