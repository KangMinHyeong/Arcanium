using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] int WaveGroupID;
    [SerializeField] int PoolSize = 150;
    [SerializeField] float BasicWaveTime = 5.0f;
    [SerializeField] int CurrentWaveNum = 0;
    [SerializeField] WaveTimePercentUI WaveTimeUI;
    
    Dictionary<int, List<EnemyWaveData>> Waves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();
    Dictionary<int, List<GameObject>> EnemyPools = new Dictionary<int, List<GameObject>>();
    
    Coroutine WaveCoroutine;
    PlayerController PC;
    WaveInfo waveInfo;

    int TotalEnemyNumber = 0;   
    int RemainWaveCount = 0; 

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        PC.stageNum = WaveGroupID;

        waveInfo = FindFirstObjectByType<WaveInfo>();

        InitWave();
        InitEnemyPools();

        StartWave();
    }

    void InitWave()
    {
        var EnemyWaves = GameManager.Instance.GetEnemyWaves;

        if(!EnemyWaves.ContainsKey(WaveGroupID)) return;

        List<EnemyWaveData> AllWaves = EnemyWaves[WaveGroupID];
        
        foreach (EnemyWaveData Wave in AllWaves)
        {
            if(!Waves.ContainsKey(Wave.WaveNum))
            {
                Waves.Add(Wave.WaveNum, new List<EnemyWaveData>{Wave});
                WaveTimes.Add(Wave.WaveNum, Wave.NextWaveTime);
            }
            else
            {
                Waves[Wave.WaveNum].Add(Wave);
                WaveTimes[Wave.WaveNum] += Wave.NextWaveTime;
            }

            
            TotalEnemyNumber += Wave.EnemyNumber;
        }

        RemainWaveCount = Waves.Count;
    }

    void InitEnemyPools()
    {
        foreach (var EnemyInfo in GameManager.Instance.GetEnemyInfos)
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

        WaveTimeUI.EndWaveTime();
        StopCoroutine(WaveCoroutine);
        WaveCoroutine = StartCoroutine(PlayWave());
    }

    IEnumerator PlayWave()
    {
        if(CurrentWaveNum == 0)
        {
            CurrentWaveNum++;
            WaveTimeUI.UpdateTime(BasicWaveTime);
            yield return new WaitForSeconds(BasicWaveTime);
        }

        while(Waves.ContainsKey(CurrentWaveNum))
        {
            int waveNum = CurrentWaveNum++;
            var EnemyWave = Waves[waveNum];

            foreach (var wave in EnemyWave)
            {
                StartCoroutine(SpawnEnemy(wave.EnemyID, wave.EnemyNumber, wave.WaveRate));
                // yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(BasicWaveTime);
            WaveTimeUI.UpdateTime(WaveTimes[waveNum]);
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
