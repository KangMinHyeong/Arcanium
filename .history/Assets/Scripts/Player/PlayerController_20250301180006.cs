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


    public int stageNum {get {return StageNum;} set {StageNum = value;}}
    public int stageGold {get {return StageGold;}}
     

    void Start()
    {
        UpdateStageData();
        UpdateGoldText();
        UpdatePlayerHPText();
    }
    
    void UpdateStageData()
    {
        var stageData = GameManager.Instance.GetStageData;

        StageHP = stageData[stageNum].StageHP;
        StageGold = stageData[stageNum].StageGold;
    }

    void UpdateGoldText()
    {
        Text_Gold.text = "Gold : "+ StageGold.ToString();
    }

    void UpdatePlayerHPText()
    {
        Text_HP.text = "HP : "+ StageHP.ToString();
    }

    public void UpdateGold(int GoldAmount)
    {
        StageGold = Mathf.Max(0, StageGold + GoldAmount);
        UpdateGoldText();
    }

    public void TakeDamage(int DamageAmount)
    {
        StageHP = Mathf.Max(0, StageHP - DamageAmount);
        UpdatePlayerHPText();

        if(StageHP == 0) DisplayDefeatUI();
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
