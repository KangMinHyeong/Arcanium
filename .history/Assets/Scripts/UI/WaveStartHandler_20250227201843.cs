using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    EnemyWave enemyWave;

    void Start()
    {
        enemyWave = FindFirstObjectByType<EnemyWave>();
    }

    public void OnClick()
    {
        enemyWave.StartWaveImmediately();
    }
}
