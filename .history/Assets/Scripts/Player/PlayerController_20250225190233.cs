using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int PlayerGold = 100;

    void UpdateGold(int GoldAmount)
    {
        PlayerGold = Mathf.Max(0, PlayerGold + GoldAmount);
    }
}
