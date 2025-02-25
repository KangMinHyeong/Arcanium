using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int EnemyGold = 10;
    [SerializeField] int MaxEnemyHP = 100;

    PlayerController PC;
    int EnemyHP = 100;
    bool bLastEnemy = false;
    public bool IsLastEnemy {set{IsLastEnemy = value;}}

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }

    void OnEnable()
    {
        EnemyHP = MaxEnemyHP;
    }

    void OnDisable()
    {
        if(bLastEnemy) PC.DisplayWinUI();
    }

    public void TakeDamage(int DamageAmount)
    {
        EnemyHP = Mathf.Max(0, EnemyHP - DamageAmount);

        if(EnemyHP == 0)
        {
            gameObject.SetActive(false);
            PC.UpdateGold(EnemyGold);
        }
    }
}
