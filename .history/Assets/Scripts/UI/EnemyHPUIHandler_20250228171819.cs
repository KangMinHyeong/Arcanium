using UnityEngine;

public class EnemyHPUIHandler : MonoBehaviour
{
    int MaxHP;
    int CurrentHP;

    public void Init(int MaxHP)
    {
        this.MaxHP = MaxHP;
        CurrentHP = MaxHP;
    }

    void Update()
    {
        
    }
}
