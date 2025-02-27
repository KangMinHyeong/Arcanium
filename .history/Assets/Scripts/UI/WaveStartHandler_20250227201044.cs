using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    EnemyWave enemyWave;

    void Start()
    {
        enemyWave = FindFirstObjectByType<EnemyWave>();
    }

    void OnClick()
    {
        enemyWave.StartWaveImmediately();
    }
}
