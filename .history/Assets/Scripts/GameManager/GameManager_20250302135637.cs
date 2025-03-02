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

    [SerializeField] GameObject LoadingUI;
    // [SerializeField] bool bTitle = false;
    
    PlayerData PlayerData = new PlayerData();

    Dictionary<int, List<EnemyWaveData>> EnemyWaves = new Dictionary<int, List<EnemyWaveData>>();
    Dictionary<int, EnemyData> EnemyInfos = new Dictionary<int, EnemyData>();

    Dictionary<int, WeaponDataStruct> WeaponDatabase = new Dictionary<int, WeaponDataStruct>();
    Dictionary<int, StageData> StageData = new Dictionary<int, StageData>();

    public PlayerData CurrentPlayerData { get {return PlayerData;} set {PlayerData = value;} }
    public Dictionary<int, List<EnemyWaveData>> GetEnemyWaves { get {return EnemyWaves;}}
    public Dictionary<int, EnemyData> GetEnemyInfos { get {return EnemyInfos;}}
    public Dictionary<int, WeaponDataStruct> GetWeaponData {get {return WeaponDatabase;}}
    public Dictionary<int, StageData> GetStageData {get {return StageData;}}

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

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void LoadData()
    {
        LoadWaveData();
        LoadEnemyData();

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

    void ActiveLoadingUI(bool IsActive)
    {
        LoadingUI.SetActive(IsActive);
    }

    public void StartLoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
     
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // SceneManager.LoadScene(sceneName);
        
        ActiveLoadingUI(true);

        float CurrentMoveTime = 0.0f;

        while (!operation.isDone)
        {
            Debug.Log($"Loading Progress: {operation.progress * 100}%"); // ✅ 로딩 퍼센트 출력
            yield return null;
        }
        // while(CurrentMoveTime < 3.0f)
        // {
        //     CurrentMoveTime += Time.deltaTime;
        //     Debug.Log($"Loading Progress: " + CurrentMoveTime); // ✅ 로딩 퍼센트 출력
        //     yield return new WaitForEndOfFrame();
        // }

        ActiveLoadingUI(false);
    }
}
