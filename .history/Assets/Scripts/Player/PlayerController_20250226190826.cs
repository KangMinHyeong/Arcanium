using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextAsset WeaponDataTable;
    [SerializeField] WeaponDatabase weaponDatabase;

    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;

    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;

    [SerializeField] int PlayerGold = 100;
    [SerializeField] int PlayerHP = 20;
    [SerializeField] TextAsset csvFile;

    public WeaponDatabase GetWeaponData {get {return weaponDatabase;}}
    public int GetPlayerGold {get {return PlayerGold;}}

    void Start()
    {
        LoadWeaponData();

        UpdateGoldText();
        UpdatePlayerHPText();
    }

    public void LoadWeaponData()
    {

        string[] lines = WeaponDataTable.text.Split('\n'); 
        weaponDatabase.weapons.Clear();

        int fieldCount = typeof(WeaponDataStruct).GetProperties().Length; // 구조체 변수 갯수
        
        for (int i = 1; i < lines.Length; i++) // 첫 줄(헤더) 제외
        {
            string[] values = lines[i].Split(',');
            if (values.Length < fieldCount) continue;

            WeaponDataStruct weapon = new WeaponDataStruct
            {
                WeaponID = int.Parse(values[0]),
                Weaponname = values[1],
                WeaponATK= int.Parse(values[2]),
                WeaponATKSpeed = float.Parse(values[3]),
                Cost = int.Parse(values[4])
            };

            weaponDatabase.weapons.Add(weapon.WeaponID, weapon);
        }
    }
    
    void UpdateGoldText()
    {
        Text_Gold.text = "Gold : "+ PlayerGold.ToString();
    }

    void UpdatePlayerHPText()
    {
        Text_HP.text = "HP : "+ PlayerHP.ToString();
    }

    public void UpdateGold(int GoldAmount)
    {
        PlayerGold = Mathf.Max(0, PlayerGold + GoldAmount);
        UpdateGoldText();
    }

    public void TakeDamage(int DamageAmount)
    {
        PlayerHP = Mathf.Max(0, PlayerHP - DamageAmount);
        UpdatePlayerHPText();

        if(PlayerHP == 0) DisplayDefeatUI();
    }

    void DisplayDefeatUI()
    {
        Time.timeScale = 0;
        DefeatUI.SetActive(true);
    }

    public void DisplayWinUI()
    {
        Time.timeScale = 0;
        WinUI.SetActive(true);
    }
}
