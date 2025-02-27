using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] TextAsset WaveDataTable;
    [SerializeField] TextAsset EnemyDataTable;
    [SerializeField] int WaveGroupID;
    [SerializeField] int PoolSize = 150;

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();

    Dictionary<int, EnemyData> EnemyInfos = new Dictionary<int, EnemyData>();

    Dictionary<int, List<GameObject>> EnemyPools = new Dictionary<int, List<GameObject>>();
    
    int TotalEnemyNumber = 0;

    void Start()
    {
        InitWave();
        InitEnemyInfos();
        InitEnemyPools();

        StartWave();
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

    void InitEnemyInfos()
    {
        EnemyDatabase Wrapper  = JsonUtility.FromJson<EnemyDatabase>(EnemyDataTable.text);

        foreach (var EnemyInfo in Wrapper.EnemyInfos)
        {
            EnemyInfos[EnemyInfo.EnemyID] = EnemyInfo;
        }
    }

    void InitEnemyPools()
    {
        foreach (var EnemyInfo in EnemyInfos)
        {
            SetEnemyPools(EnemyInfo.Key, EnemyInfo.Value);
        }
    }

    void SetEnemyPools(int EnemyID, EnemyData EnemyInfo)
    {
        var EnemyPrefab = Resources.Load<GameObject>(EnemyInfo.EnemyPrefabPath);
        List<GameObject> Enemies = new List<GameObject>();

        for(int i = 0; i<PoolSize; i++)
        {
            var Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity, transform);
            Enemy.SetActive(false);
            Enemies.Add(Enemy);
        }

        EnemyPools[EnemyID] = Enemies;
    }
    

    public void StartWave()
    {
        StartCoroutine(PlayWave());
    }

    IEnumerator PlayWave()
    {
        int CurrentWaveNum = 1;

        while(EnemyWaves.ContainsKey(CurrentWaveNum))
        {
            var EnemyWave = EnemyWaves[CurrentWaveNum];
            Debug.Log(EnemyWave.Count);

            foreach (var wave in EnemyWave)
            {
                StartCoroutine(SpawnEnemy(wave.EnemyID, wave.EnemyNumber, wave.WaveRate));
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(WaveTimes[CurrentWaveNum]);
            CurrentWaveNum++;
        }
    }

    IEnumerator SpawnEnemy(int EnemyID, int EnemyNumber, float WaveRate)
    {
        while(EnemyNumber-- > 0)
        {
            foreach(var Enemy in EnemyPools[EnemyID])
            {
                if(!Enemy.activeInHierarchy)
                {
                    Enemy.SetActive(true);
                    TotalEnemyNumber--;
                    if(TotalEnemyNumber == 0)
                    {
                        Enemy.GetComponent<Enemy>().IsLastEnemy = true;
                    }
                    break;
                }
            }
            yield return new WaitForSeconds(WaveRate);
        }
    }

}
