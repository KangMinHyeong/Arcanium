using UnityEngine;
using System.Collections.Generic;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] TextAsset WaveDataTable;
    [SerializeField] int WaveGroupID;

    HashSet<GameObject> EnemyPrefabs;

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        List<EnemyWaveData> CurrentWave = new List<EnemyWaveData>();
        float WaveTime = 0.0f;

        int waveNum = 1;

        foreach (var Wave in Wrapper.Waves)
        {
            if(Wave.WaveGroupID != WaveGroupID) continue;
            
            if(waveNum != Wave.WaveNum)
            {
                EnemyWaves[waveNum] = CurrentWave;
                WaveTimes[waveNum] = WaveTime;

                CurrentWave.Clear();
                WaveTime = 0.0f;

                waveNum = Wave.WaveNum;
            }

            CurrentWave.Add(Wave);
            WaveTime += Wave.NextWaveTime;
        }

        if(CurrentWave.Count != 0) EnemyWaves[waveNum] = CurrentWave;
    }


}
