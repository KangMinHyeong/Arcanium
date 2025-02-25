using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    
    Rigidbody rb;
    Transform Target;
    string CollisionEnableTag = "";
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

    public void Init(int DamageAmount, string CollisionEnableTag, Transform Target)
    {
        this.DamageAmount = DamageAmount;
        this.CollisionEnableTag = CollisionEnableTag;
        this.Target = Target;
    }

    void Update()
    {
        if(!bRunning) return;

        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * ProjectileSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != CollisionEnableTag && other.tag != "Obstacle") return;

        if(other.tag == CollisionEnableTag) ApplyDamage(other);
        this.gameObject.SetActive(false);
    }

    void ApplyDamage(Collider other)
    {
        var EnemyHealth = other.GetComponentInParent<EnemyHealth>();
        if(EnemyHealth) EnemyHealth.TakeDamage(DamageAmount);
    }
}
