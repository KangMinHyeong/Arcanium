using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int EnemyGold = 10;
    [SerializeField] int MaxEnemyHP = 100;

    PlayerController PC;
    int EnemyHP = 100;
    bool bLastEnemy = false;
    public bool IsLastEnemy {set{bLastEnemy = value;}}

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

    void Init(EnemyData EnemyInfo)
    {

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

    public void ApplyDamage()
    {
        PC.TakeDamage(1);
    }

}
