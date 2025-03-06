using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DeadVFX;
    [SerializeField] float KillDelayTime = 1.65f;
    
    PlayerController PC;
    EnemyWave enemyWave;

    EnemyHPUIHandler HPUI;
    int EnemyHP = 100;

    // Initialize Data
    int EnemyGold = 10;
    int MaxEnemyHP = 100;

    bool bDead = false;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        HPUI = GetComponentInChildren<EnemyHPUIHandler>();
    }

    void OnEnable()
    {
        EnemyHP = MaxEnemyHP;
        bDead = false;
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
        if(bDead) return;
        if(!HPUI.Active) HPUI.SetActive();

        EnemyHP = Mathf.Max(0, EnemyHP - DamageAmount);
        if(HPUI) HPUI.UpdateHP((float)EnemyHP / MaxEnemyHP);

        if(EnemyHP == 0)
        {
            PlayDeadEffect();

            bDead = true;
            PC.UpdateGold(EnemyGold);
            GetComponentInChildren<EnemyMover>().Stop();
            Invoke("KillEnemy", KillDelayTime);
        }
    }

    private void PlayDeadEffect()
    {
        var pos = transform.position + new Vector3(0.0f, 1.5f, 0.0f);

        // DeadVFX.Play();
        Instantiate(DeadVFX, pos, Quaternion.identity); 
        GameManager.Instance.PlayTextVFX(pos);
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
        GetComponentInChildren<EnemyMover>().enabled = true;
        // Enemy가 다 죽었는지 체크z
        enemyWave.CheckClear(PC);
    }

    public void ApplyDamage()
    {
        PC.TakeDamage(1);
        enemyWave.CheckClear(PC);

        gameObject.SetActive(false);
    }

}
