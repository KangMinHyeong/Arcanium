using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    
    Rigidbody rb;
    Transform Target;
    int DamageAmount;
    bool bRunning = false;


    void OnEnable()
    {
        bRunning = true;
    }

    void OnDisable()
    {
        bRunning = false;
    }

    public void Init(int DamageAmount, Transform Target)
    {
        this.DamageAmount = DamageAmount;
        this.Target = Target;
    }

    void Update()
    {
        if(!bRunning || !Target) return;

        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * ProjectileSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            this.gameObject.SetActive(false);
            bRunning = false;
        }
        else if(other.transform == Target)
        {
            ApplyDamage(other);
            this.gameObject.SetActive(false);
            bRunning = false;
        }
    }

    void ApplyDamage(Collider other)
    {
        var EnemyHealth = other.GetComponentInParent<EnemyHealth>();
        if(EnemyHealth) EnemyHealth.TakeDamage(DamageAmount);
    }
}
