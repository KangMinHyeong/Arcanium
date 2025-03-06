using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    EnemyWave enemyWave;

    void Start()
    {
        enemyWave = GetComponentInParent<EnemyWave>();
    }

    public void OnClick()
    {
        enemyWave.StartWaveImmediately();
    }
}
