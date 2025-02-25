using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int Gold = 100;


    void UpdateGold(int GoldAmount)
    {
        Gold = Mathf.Max(0, Gold + GoldAmount);
    }
}
