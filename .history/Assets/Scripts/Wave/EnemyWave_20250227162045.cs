using UnityEngine;
using System.Collections.Generic;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] TextAsset WaveDataTable;

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        foreach (var Wave in Wrapper.Waves)
        {
            WeaponDatabase[weapon.WeaponID] = weapon;
        }
    }
}
