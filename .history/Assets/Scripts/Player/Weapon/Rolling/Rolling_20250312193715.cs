using UnityEngine;

public class Rolling : MonoBehaviour
{
    int Damage = 0;

    public void Init(int Damage, ParticleSystem HitVFX)
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
