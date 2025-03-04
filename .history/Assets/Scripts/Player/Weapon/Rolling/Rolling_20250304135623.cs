using UnityEngine;

public class Rolling : MonoBehaviour
{
    int Damage = 0;

    void SetDamage(int Damage)
    {

    }

    void OggerEnter(Collider other)
    {
        var Enemy = other.GetComponentInParent<Enemy>();
        if(Enemy)
        {
            Enemy.TakeDamage()
        }
    }
}
