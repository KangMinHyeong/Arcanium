using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    
    Rigidbody rb;
    Transform Target;
    Vector3 lastTargetPos;
    ParticleSystem HitVFX;

    int DamageAmount;
    bool bRunning = false;
    bool bDestroy = false;

    public bool HasDestroy {set {bDestroy = value;}}

    void OnEnable()
    {
        bRunning = true;
    }

    void OnDisable()
    {
        bRunning = false;
    }

    public void Init(int DamageAmount, Transform Target, ParticleSystem HitVFX)
    {
        this.DamageAmount = DamageAmount;
        this.Target = Target;
        this.HitVFX = HitVFX;

        lastTargetPos = Target.position;
    }

    void Update()
    {
        if(Target)
        {
            if(bRunning && Target.gameObject.activeInHierarchy)
            {
                lastTargetPos = Target.position;
            }
            else {Target = null;}
        }       

        Vector3 direction = (lastTargetPos - transform.position).normalized;
        transform.position += direction * ProjectileSpeed * Time.deltaTime;
        transform.LookAt(Target);

        if(Vector3.Distance(lastTargetPos, transform.position) <= 0.1f)
        {
            Debug.Log("Deactive");
            Deactive();
        }
    }

    void Deactive()
    {
        if(bDestroy) 
        {
            Destroy(transform.parent.gameObject);
            return;
        }

        this.gameObject.SetActive(false);
        bRunning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Deactive();
        }
        else if(other.gameObject.transform.parent == Target)
        {
            Instantiate(HitVFX, Target.position, Quaternion.identity);
            ApplyDamage(other);
            Deactive();
        }
    }

    void ApplyDamage(Collider other)
    {
        var EnemyHealth = other.GetComponentInParent<Enemy>();
        if(EnemyHealth) EnemyHealth.TakeDamage(DamageAmount);
    }
}
