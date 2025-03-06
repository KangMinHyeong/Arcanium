using UnityEngine;

public class WaveStartHandler : MonoBehaviour
{
    [SerializeField] EnemyWave enemyWave;

    public void OnClick()
    {
        enemyWave.StartWaveImmediately();
    }
}
