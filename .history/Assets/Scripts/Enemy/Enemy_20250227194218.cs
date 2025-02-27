using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController PC;
    EnemyWave enemyWave;

    int EnemyHP = 100;

    // Initialize Data
    int EnemyGold = 10;
    int MaxEnemyHP = 100;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }

    void OnEnable()
    {
        EnemyHP = MaxEnemyHP;
    }

    public void Init(EnemyWave enemyWave, EnemyData EnemyInfo)
    {
        this.enemyWave = enemyWave;

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

            // Enemy가 다 죽었는지 체크
            enemyWave.CheckClear();
        }
    }

    public void ApplyDamage()
    {
        PC.TakeDamage(1);
    }

}
