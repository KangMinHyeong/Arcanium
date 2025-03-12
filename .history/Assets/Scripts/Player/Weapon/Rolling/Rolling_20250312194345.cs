using UnityEngine;

public class Rolling : MonoBehaviour
{
    int Damage = 0;
    ParticleSystem HitVFX;

    public void Init(int Damage, ParticleSystem HitVFX)
    {
        this.Damage = Damage;
        this.HitVFX = HitVFX;
    }

    void OnTriggerEnter(Collider other)
    {
        var Enemy = other.GetComponentInParent<Enemy>();
        if(Enemy)
        {
            Enemy.TakeDamage(Damage);
            Instantiate(HitVFX, transform.position, Quaternion.identity);
        }
    }
}
