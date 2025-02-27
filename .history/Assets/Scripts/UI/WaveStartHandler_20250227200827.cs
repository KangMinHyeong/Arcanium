using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    EnemyWave enemyWave;

    void Start()
    {
        enemyWave = FindFirstObjectByType<EnemyWave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
