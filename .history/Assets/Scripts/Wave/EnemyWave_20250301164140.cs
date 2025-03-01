using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] int WaveGroupID;
    [SerializeField] int PoolSize = 150;
    [SerializeField] float FirstWaveTime = 5.0f;
    [SerializeField] int CurrentWaveNum = 0;

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();

    Dictionary<int, EnemyData> EnemyInfos = new Dictionary<int, EnemyData>();

    Dictionary<int, List<GameObject>> EnemyPools = new Dictionary<int, List<GameObject>>();
    
    Coroutine WaveCoroutine;

    int TotalEnemyNumber = 0;
    

    void Start()
    {
        InitEnemyInfos();
        InitEnemyPools();

        StartWave();
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
            Enemy.GetComponent<Enemy>().Init(this, EnemyInfo);
            Enemy.SetActive(false);
            Enemies.Add(Enemy);
        }

        EnemyPools[EnemyID] = Enemies;
    }
    

    public void StartWave()
    {
        WaveCoroutine = StartCoroutine(PlayWave());
    }

    public void StartWaveImmediately()
    {
        if(WaveCoroutine == null) return;

        StopCoroutine(WaveCoroutine);
        WaveCoroutine = StartCoroutine(PlayWave());
    }

    IEnumerator PlayWave()
    {
        if(CurrentWaveNum == 0)
        {
            CurrentWaveNum++;
            yield return new WaitForSeconds(FirstWaveTime);
        }

        while(EnemyWaves.ContainsKey(CurrentWaveNum))
        {
            int waveNum = CurrentWaveNum++;
            var EnemyWave = EnemyWaves[waveNum];

            foreach (var wave in EnemyWave)
            {
                StartCoroutine(SpawnEnemy(wave.EnemyID, wave.EnemyNumber, wave.WaveRate));
                // yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(WaveTimes[waveNum]);
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
                    break;
                }
            }
            yield return new WaitForSeconds(WaveRate);
        }
    }

    public void CheckClear(PlayerController PC)
    {
        TotalEnemyNumber--;
        if(TotalEnemyNumber == 0)
        {
            PC.DisplayWinUI();
        }
    }

}
