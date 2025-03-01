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
    Dictionary<int, EnemyData> EnemyInfos = new Dictionary<int, EnemyData>();


    public PlayerData CurrentPlayerData { get; set; }
    public Dictionary<int, List<EnemyWaveData>> GetEnemyWaves { get;}
    public Dictionary<int, EnemyData> GetEnemyInfos { get;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
            LoadData();
            Debug.Log("LoadData");
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    void LoadData()
    {
        LoadWave();
        LoadEnemyInfos();
    }

    void LoadWave()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        if(Wrapper.Waves.Count == 0) return;

        foreach (var Wave in Wrapper.Waves)
        {
            if(!EnemyWaves.ContainsKey(Wave.WaveGroupID))
            {
                EnemyWaves.Add(Wave.WaveGroupID, new List<EnemyWaveData>());
            }

            EnemyWaves[Wave.WaveGroupID].Add(Wave);  
        }
    }

    void LoadEnemyInfos()
    {
        EnemyDatabase Wrapper  = JsonUtility.FromJson<EnemyDatabase>(EnemyDataTable.text);

        foreach (var EnemyInfo in Wrapper.EnemyInfos)
        {
            EnemyInfos[EnemyInfo.EnemyID] = EnemyInfo;
        }
    }
}
