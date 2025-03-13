using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] WaveTimePercentUI WaveTimeUI;
    
    [SerializeField] float FirstWaveTime = 15.0f;
    [SerializeField] float BasicWaveTime = 5.0f;
    [SerializeField] int WaveGroupID; // == Stage Index
    [SerializeField] int PoolSize = 150; // 각 Enemy마다 가지게 될 오브젝트 풀 사이즈
    
    // Wave 번호마다 플레이 될 각각의 Wave들
    Dictionary<int, List<EnemyWaveData>> Waves = new Dictionary<int, List<EnemyWaveData>>();
    // 각 Wave번호마다 다음 웨이브까지 소요되는 시간들
    Dictionary<int, float> WaveTimes = new Dictionary<int, float>();
    // 각 Enemy마다 가지게 될 오브젝트 풀
    Dictionary<int, List<GameObject>> EnemyPools = new Dictionary<int, List<GameObject>>();
    
    Coroutine WaveCoroutine;
    PlayerController PC;
    WaveInfo waveInfo;

    int TotalEnemyNumber = 0;   
    int TotleWaveCount = 0; 
    int CurrentWaveNum = 0;
    

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

        TotleWaveCount = Waves.Count;
        waveInfo.UpdateWaveCount(TotleWaveCount);
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

    // Start Now 버튼 클릭 시
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
            waveInfo.UpdateWaveCount(TotleWaveCount - CurrentWaveNum);

            CurrentWaveNum++;

            waveInfo.UpdateWaveInfo(Waves[CurrentWaveNum]);
            yield return new WaitForSeconds(BasicWaveTime);

            WaveTimeUI.UpdateTime(FirstWaveTime);    
            yield return new WaitForSeconds(FirstWaveTime);
        }

        while(Waves.ContainsKey(CurrentWaveNum))
        {
            int waveNum = CurrentWaveNum++;
            var EnemyWave = Waves[waveNum];

            foreach (var wave in EnemyWave)
            {
                StartCoroutine(SpawnEnemy(wave.EnemyID, wave.EnemyNumber, wave.WaveRate));
            }

            waveInfo.UpdateWaveCount(TotleWaveCount - waveNum);
            
            yield return new WaitForSeconds(BasicWaveTime);

            if(TotleWaveCount != waveNum) waveInfo.UpdateWaveInfo(Waves[waveNum+1]);
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
