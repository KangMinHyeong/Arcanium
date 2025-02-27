using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] TextAsset WaveDataTable;
    [SerializeField] int WaveGroupID;
    [SerializeField] int PoolSize = 150;

    HashSet<string> EnemyPrefabPaths = new HashSet<string>();
    Dictionary<string, List<GameObject>> EnemyPools = new Dictionary<string, List<GameObject>>();

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();

    int CurrentWaveNum = 0;

    void Start()
    {
        Init();
        InitEnemyPools();
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
            EnemyPrefabPaths.Add(Wave.EnemyPrefabPath);
        }

        if(CurrentWave.Count != 0)
        {
            EnemyWaves[waveNum] = CurrentWave;
            WaveTimes[waveNum] = WaveTime;
        }
    }

    void InitEnemyPools()
    {
        foreach (var EnemyPrefabPath in EnemyPrefabPaths)
        {
            var EnemyPrefab = Resources.Load<GameObject>(EnemyPrefabPath);
            
            SetEnemyPools(EnemyPrefabPath, EnemyPrefab);
        }
    }

    void SetEnemyPools(string EnemyPrefabPath, GameObject EnemyPrefab)
    {
        List<GameObject> Enemies = new List<GameObject>();

        for(int i = 0; i<PoolSize; i++)
        {
            var Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            Enemy.SetActive(false);
            Enemies.Add(Enemy);
        }

        EnemyPools[EnemyPrefabPath] = Enemies;
    }
    

    public void StartWave()
    {
        StartCoroutine(PlayWave());
    }

    IEnumerator PlayWave()
    {
        while(EnemyWaves.ContainsKey(CurrentWaveNum))
        {
            
            // To Do Spawn Enemy
            yield return new WaitForSeconds(WaveTimes[CurrentWaveNum]);
            CurrentWaveNum++;
        }
    }

}
