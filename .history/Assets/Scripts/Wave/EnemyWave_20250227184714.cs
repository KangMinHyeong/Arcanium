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

    int TotalEnemyNumber = 0;

    void Start()
    {
        Init();
        InitEnemyPools();
        StartWave();
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
                EnemyWaves[waveNum] = new List<EnemyWaveData>(CurrentWave);
                WaveTimes[waveNum] = WaveTime;
                
                CurrentWave.Clear();
                WaveTime = 0.0f;

                waveNum = Wave.WaveNum;
            }

            CurrentWave.Add(Wave);
            WaveTime += Wave.NextWaveTime;
            EnemyPrefabPaths.Add(Wave.EnemyPrefabPath);
            
            TotalEnemyNumber += Wave.EnemyNumber;
        }

        if(CurrentWave.Count != 0)
        {
            EnemyWaves[waveNum] = new List<EnemyWaveData>(CurrentWave);
            WaveTimes[waveNum] = WaveTime;
        }

        
        // Debug.Log("aa" + EnemyWaves[2].Count);
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
            var Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity, transform);
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
        int CurrentWaveNum = 1;

        while(EnemyWaves.ContainsKey(CurrentWaveNum))
        {
            var EnemyWave = EnemyWaves[CurrentWaveNum];
            Debug.Log(EnemyWave.Count);

            foreach (var wave in EnemyWave)
            {
                StartCoroutine(SpawnEnemy(wave.EnemyPrefabPath, wave.EnemyNumber, wave.WaveRate));
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(WaveTimes[CurrentWaveNum]);
            CurrentWaveNum++;
        }
    }

    IEnumerator SpawnEnemy(string EnemyPrefabPath, int EnemyNumber, float WaveRate)
    {
        while(EnemyNumber-- > 0)
        {
            foreach(var Enemy in EnemyPools[EnemyPrefabPath])
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
