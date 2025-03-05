using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextAsset WaveDataTable;
    [SerializeField] TextAsset EnemyDataTable;
    [SerializeField] TextAsset StageDataTable;
    [SerializeField] TextAsset WeaponDataTable;
    [SerializeField] TextAsset SkillDataTable;

    [SerializeField] GameObject LoadingUI;
    // [SerializeField] bool bTitle = false;
    
    int ClearStageNumber = 0;
    float StageTimeScale = 1.0f;

    PlayerData PlayerData = new PlayerData();

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, EnemyData> EnemyInfos = new Dictionary<int, EnemyData>();

    Dictionary<int, PlayerSkillData> SkillDatabase = new Dictionary<int, PlayerSkillData>();
    Dictionary<int, WeaponDataStruct> WeaponDatabase = new Dictionary<int, WeaponDataStruct>();
    Dictionary<int, StageData> StageData = new Dictionary<int, StageData>();

    public PlayerData CurrentPlayerData { get {return PlayerData;} set {PlayerData = value;} }
    public Dictionary<int, List<EnemyWaveData>> GetEnemyWaves { get {return EnemyWaves;}}
    public Dictionary<int, EnemyData> GetEnemyInfos { get {return EnemyInfos;}}
    public Dictionary<int, PlayerSkillData> GetSkillData {get {return SkillDatabase;}}
    public Dictionary<int, WeaponDataStruct> GetWeaponData {get {return WeaponDatabase;}}
    public Dictionary<int, StageData> GetStageData {get {return StageData;}}

    public int clearStageNumber {get {return ClearStageNumber;} set {ClearStageNumber = value;}}
    public float stageTimeScale {get {return StageTimeScale;} set {StageTimeScale = value;}}

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
        LoadWaveData();
        LoadEnemyData();

        LoadSkillData();
        LoadWeaponData();
        LoadStageData();
    }

    void LoadWaveData()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        if(Wrapper.Waves.Count == 0) return;

        foreach (var Wave in Wrapper.Waves)
        {
            if(!EnemyWaves.ContainsKey(Wave.WaveGroupID))
            {
                EnemyWaves.Add(Wave.WaveGroupID, new List<EnemyWaveData>{Wave});
            }
            else
            {
                EnemyWaves[Wave.WaveGroupID].Add(Wave);  
            }
        }
    }

    void LoadEnemyData()
    {
        EnemyDatabase Wrapper  = JsonUtility.FromJson<EnemyDatabase>(EnemyDataTable.text);

        foreach (var EnemyInfo in Wrapper.EnemyInfos)
        {
            EnemyInfos[EnemyInfo.EnemyID] = EnemyInfo;
        }
    }

    void LoadSkillData()
    {
        PlayerSkillDatabase Wrapper  = JsonUtility.FromJson<PlayerSkillDatabase>(SkillDataTable.text);
        
        foreach (var Skill in Wrapper.Skills)
        {
            SkillDatabase[Skill.SkillID] = Skill;
        }
    }

    void LoadWeaponData()
    {
        WeaponDatabase Wrapper  = JsonUtility.FromJson<WeaponDatabase>(WeaponDataTable.text);
        
        foreach (var weapon in Wrapper.weapons)
        {
            WeaponDatabase[weapon.WeaponID] = weapon;
        }
    }

    void LoadStageData()
    {
        StageDatabase Wrapper  = JsonUtility.FromJson<StageDatabase>(StageDataTable.text);
        
        foreach (var Stage in Wrapper.Stages)
        {
            StageData[Stage.StageID] = Stage;
        }
    }

    public void UpgradeATK_Add(int ATKAmount)
    {
        PlayerData.PlayerATK += ATKAmount;
    }

    public void UpgradeATK_Multiple(float ATKCoefficient)
    {
        PlayerData.PlayerATK = (int)(ATKCoefficient * PlayerData.PlayerATK);
    }

    public void UpgradeATKSpeed(float ATKSpeedCoefficient)
    {
        PlayerData.PlayerATKSpeed *= ATKSpeedCoefficient;
    }

    void ActiveLoadingUI(bool IsActive)
    {
        LoadingUI.SetActive(IsActive);
    }

    public void StartLoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void StartLoadScene(int sceneindex)
    {
        StartCoroutine(LoadSceneAsync(sceneindex));
    }

    public void StartLastStage()
    {
        string sceneName = "Stage" + ClearStageNumber.ToString();
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void StartStage(int stageNum)
    {
        string sceneName = "Stage" + stageNum.ToString();
        StartCoroutine(LoadSceneAsync(sceneName));
    }
     
    IEnumerator LoadSceneAsync(string sceneName)
    {
        Time.timeScale = 1.0f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        ActiveLoadingUI(true);

        float CurrentMoveTime = 0.0f;
        while (!operation.isDone || CurrentMoveTime < 1.5f)
        {
            CurrentMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        ActiveLoadingUI(false);
    }

    IEnumerator LoadSceneAsync(int sceneindex)
    {
        Time.timeScale = 1.0f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        
        ActiveLoadingUI(true);

        float CurrentMoveTime = 0.0f;
        while (!operation.isDone || CurrentMoveTime < 1.5f)
        {
            CurrentMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        ActiveLoadingUI(false);
    }
}
