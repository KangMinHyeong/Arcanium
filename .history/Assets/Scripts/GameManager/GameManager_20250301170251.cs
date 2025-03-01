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
    
    public Dictionary<int, List<EnemyWaveData>> GetEnemyWaves { get;}
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
        LoadWave();
    }

    void LoadWave()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        if(Wrapper.Waves.Count == 0) return;

        // float WaveTime = 0.0f;
        // int WaveGroupID = Wrapper.Waves[0].WaveGroupID;

        foreach (var Wave in Wrapper.Waves)
        {
            // if(Wave.WaveGroupID != WaveGroupID) continue;
            EnemyWaves[Wave.WaveGroupID].Add(Wave);
            
            
        }

        // if(CurrentWave.Count != 0)
        // {
        //     EnemyWaves[waveNum] = new List<EnemyWaveData>(CurrentWave);
        //     WaveTimes[waveNum] = WaveTime;
        // }
    }
}
