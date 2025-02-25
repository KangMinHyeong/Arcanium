using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text_Gold;
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

    public void UpdateGold(int GoldAmount)
    {
        PlayerGold = Mathf.Max(0, PlayerGold + GoldAmount);
        UpdateGoldText();
    }
}
