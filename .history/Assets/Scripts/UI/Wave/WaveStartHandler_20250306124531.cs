using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    // EnemyWave enemyWave;

    void Start()
    {
    }

    public void OnClick()
    {
        GetComponentInParent<EnemyWave>().StartWaveImmediately();
    }
}
