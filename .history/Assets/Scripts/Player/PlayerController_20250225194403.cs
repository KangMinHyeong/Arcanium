using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject EndUI;
    [SerializeField] TextMeshProUGUI Text_Gold;
    [SerializeField] TextMeshProUGUI Text_HP;
    [SerializeField] int PlayerGold = 100;
    [SerializeField] int PlayerHP = 20;

    public int GetPlayerGold {get {return PlayerGold;}}

    void Start()
    {
        UpdateGoldText();
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
        PlayerHP = Mathf.Max(0, PlayerHP + DamageAmount);
        UpdatePlayerHPText();

        if(PlayerHP == 0)
        {
            Time.timeScale = 0;
            EndUI.SetActive(true);
        }
    }
}
