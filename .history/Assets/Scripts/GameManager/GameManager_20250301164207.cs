using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextAsset WaveDataTable;
    [SerializeField] TextAsset EnemyDataTable;


    PlayerData PlayerData;

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();

    public PlayerData CurrentPlayerData { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
            LoadData();
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void LoadData()
    {
        InitWave();
    }


    void InitWave()
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
                EnemyWaves[waveNum] = new List<EnemyWaveData>(CurrentWave);
                WaveTimes[waveNum] = WaveTime;
                
                CurrentWave.Clear();
                WaveTime = 0.0f;

                waveNum = Wave.WaveNum;
            }

            CurrentWave.Add(Wave);
            WaveTime += Wave.NextWaveTime;
                        
            TotalEnemyNumber += Wave.EnemyNumber;
        }

        if(CurrentWave.Count != 0)
        {
            EnemyWaves[waveNum] = new List<EnemyWaveData>(CurrentWave);
            WaveTimes[waveNum] = WaveTime;
        }
    }
}
