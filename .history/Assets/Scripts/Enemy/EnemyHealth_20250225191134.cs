using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int EnemyGold = 10;
    [SerializeField] int MaxEnemyHP = 100;

    PlayerController PC;
    int EnemyHP = 100;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }

    void OnEnable()
    {
        EnemyHP = MaxEnemyHP;
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
