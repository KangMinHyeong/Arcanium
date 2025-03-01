using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;

    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;


    GameObject LastClickUI;

    int StageNum;
    int StageGold;
    int StageHP;

    bool bDefeat = false;


    public int stageNum {get {return stageNum;} set {stageNum = value;}}
    public int stageGold {get {return StageGold;}}
     

    void Start()
    {
        UpdateGoldText();
        UpdatePlayerHPText();
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
        bDefeat = true;
        Time.timeScale = 0;
        DefeatUI.SetActive(true);
    }

    public void DisplayWinUI()
    {
        if(bDefeat) return;
        
        Time.timeScale = 0;
        WinUI.SetActive(true);
    }

    public void CloseLastClickUI(GameObject ClickUI = null)
    {
        if(LastClickUI) LastClickUI.SetActive(false);

        LastClickUI = ClickUI;
    }
    
}
