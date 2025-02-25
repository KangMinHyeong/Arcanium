using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    
    Rigidbody rb;
    Transform Target;
    Vector3 lastTargetPos;
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
        lastTargetPos = Target.position;
    }

    void Update()
    {
        if(bRunning && Target && Target.gameObject.activeInHierarchy)
        {
            lastTargetPos = Target.position;
            return;
        }

        Vector3 direction = (lastTargetPos - transform.position).normalized;
        transform.position += direction * ProjectileSpeed * Time.deltaTime;
        transform.LookAt(Target);

        if(Vector3.Distance(lastTargetPos, transform.position) <= 0.5f)
        {
            Deactive();
        }
    }

    void Deactive()
    {
        this.gameObject.SetActive(false);
        bRunning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Deactive();
        }
        else if(other.transform == Target)
        {
            ApplyDamage(other);
            Deactive();
        }
    }

    void ApplyDamage(Collider other)
    {
        var EnemyHealth = other.GetComponentInParent<EnemyHealth>();
        if(EnemyHealth) EnemyHealth.TakeDamage(DamageAmount);
    }
}
