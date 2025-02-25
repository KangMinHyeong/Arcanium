using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxEnemyHP = 100;

    int EnemyHP = 100;

    void OnEnable()
    {
        EnemyHP = MaxEnemyHP;
    }

    void TakeDamage(int DamageAmount)
    {
        EnemyHP = Mathf.Max(0, EnemyHP - DamageAmount);

        if(EnemyHP == 0)
        {
            // 오브젝트 비활성화
        }
    }
}
