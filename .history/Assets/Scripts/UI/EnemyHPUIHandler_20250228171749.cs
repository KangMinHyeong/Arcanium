using UnityEngine;

public class EnemyHPUIHandler : MonoBehaviour
{
    int MaxHP;
    int CurrentHP;

    void Init(int MaxHP)
    {
        this.MaxHP = MaxHP;
        CurrentHP = MaxHP;
    }

    void Update()
    {
        
    }
}
