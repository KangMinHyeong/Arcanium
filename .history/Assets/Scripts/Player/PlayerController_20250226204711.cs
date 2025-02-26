using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] TextAsset WeaponDataTable;

    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;

    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;

    [SerializeField] int PlayerGold = 100;
    [SerializeField] int PlayerHP = 20;
    [SerializeField] TextAsset csvFile;

    Dictionary<int, WeaponDataStruct> WeaponDatabase = new Dictionary<int, WeaponDataStruct>();

    public Dictionary<int, WeaponDataStruct> GetWeaponData {get {return WeaponDatabase;}}
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
        
        WeaponDatabase Wrapper  = JsonUtility.FromJson<WeaponDatabase>(WeaponDataTable.text);
        
        foreach (var weapon in Wrapper.weapons)
        {
            WeaponDatabase[weapon.WeaponID] = weapon;
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
