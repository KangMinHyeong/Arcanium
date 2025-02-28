using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyHPUI;

    PlayerController PC;
    EnemyWave enemyWave;

    Image HPUI;
    int EnemyHP = 100;

    // Initialize Data
    int EnemyGold = 10;
    int MaxEnemyHP = 100;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        HPUI = EnemyHPUI.GetComponentInChildren<Image>();
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

        GetComponentInChildren<EnemyMover>().Init(this, EnemyInfo);
    }

    public void TakeDamage(int DamageAmount)
    {
        EnemyHP = Mathf.Max(0, EnemyHP - DamageAmount);

        if(EnemyHP == 0)
        {
            gameObject.SetActive(false);
            PC.UpdateGold(EnemyGold);

            // Enemy가 다 죽었는지 체크
            enemyWave.CheckClear(PC);
        }
    }

    public void ApplyDamage()
    {
        PC.TakeDamage(1);
        enemyWave.CheckClear(PC);

        gameObject.SetActive(false);
    }

}
