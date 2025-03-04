using UnityEngine;

public class Rolling : MonoBehaviour
{
    int Damage = 0;

    public void SetDamage(int Damage)
    {
        this.Damage = Damage;
    }

    void OnTriggerEnter(Collider other)
    {
        var Enemy = other.GetComponentInParent<Enemy>();
        if(Enemy)
        {
            Enemy.TakeDamage(Damage);
        }
    }
}
