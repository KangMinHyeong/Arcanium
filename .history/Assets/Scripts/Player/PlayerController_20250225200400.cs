using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject WinUI;
    [SerializeField] GameObject DefeatUI;
    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;
    [SerializeField] int PlayerGold = 100;
    [SerializeField] int PlayerHP = 20;

    public int GetPlayerGold {get {return PlayerGold;}}

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
        Debug.Log("dfs");
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
        Debug.Log("DisplayWinUI");
        Time.timeScale = 0;
        WinUI.SetActive(true);
    }
}
