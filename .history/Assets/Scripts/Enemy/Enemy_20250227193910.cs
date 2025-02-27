using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController PC;
    int EnemyHP = 100;
    bool bLastEnemy = false;

    // Initialize Data
    int EnemyGold = 10;
    int MaxEnemyHP = 100;


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

    public void Init(EnemyData EnemyInfo)
    {
        MaxEnemyHP = EnemyInfo.EnemyHP;
        EnemyGold = EnemyInfo.EnemyGold;

        GetComponentInChildren<EnemyMover>().Init(EnemyInfo);
    }

    public void TakeDamage(int DamageAmount)
    {
        EnemyHP = Mathf.Max(0, EnemyHP - DamageAmount);

        if(EnemyHP == 0)
        {
            gameObject.SetActive(false);
            PC.UpdateGold(EnemyGold);

            // Enemy가 다 죽었는지 체크크
        }
    }

    public void ApplyDamage()
    {
        PC.TakeDamage(1);
    }

}
