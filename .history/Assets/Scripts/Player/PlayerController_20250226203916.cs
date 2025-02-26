using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] TextAsset WeaponDataTable;
    [SerializeField] WeaponDatabase WeaponDatabase;

    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;

    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;

    [SerializeField] int PlayerGold = 100;
    [SerializeField] int PlayerHP = 20;
    [SerializeField] TextAsset csvFile;

    public WeaponDatabase GetWeaponData {get {return WeaponDatabase;}}
    public int GetPlayerGold {get {return PlayerGold;}}

    void Awake()
    {
        LoadWeaponData();
    }

    void Start()
    {
        UpdateGoldText();
        UpdatePlayerHPText();
    }

    public void LoadWeaponData()
    {
        Debug.Log(WeaponDataTable.text);
        WeaponDatabaseWrapper Wrapper  = JsonUtility.FromJson<WeaponDatabaseWrapper>(WeaponDataTable.text);
        
        // WeaponDatabase.weapons.Clear();
        // int fieldCount = typeof(WeaponDataStruct).GetProperties().Length; // 구조체 변수 갯수


        foreach (var weapon in WeaponDatabase.weapons)
        {
            Debug.Log("WeaponDataTable.text");
        }
        // for (int i = 1; i < lines.Length; i++) // 첫 줄(헤더) 제외
        // {
        //     string[] values = lines[i].Split(',');
        //     if (values.Length < fieldCount) continue;

        //     WeaponDataStruct weapon = new WeaponDataStruct
        //     {
        //         WeaponID = int.Parse(values[0]),
        //         Weaponname = values[1],

        //         WeaponPrefabPath = values[2],
        //         WeaponModelPrefabPath = values[3],

        //         Cost = int.Parse(values[4]),

        //         WeaponATK= int.Parse(values[5]),
        //         WeaponATKSpeed = float.Parse(values[6]),                
        //     };

        //     weaponDatabase.weapons.Add(weapon.WeaponID, weapon);
        // }
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
