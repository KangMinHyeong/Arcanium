using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    
    Rigidbody rb;

    string CollisionEnableTag = "";
    int DamageAmount;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rb.linearVelocity = transform.forward * ProjectileSpeed;
    }

    void OnDisable()
    {
        rb.linearVelocity = transform.forward * 0.0f;
    }

    public void Init(int DamageAmount, string CollisionEnableTag)
    {
        this.DamageAmount = DamageAmount;
        this.CollisionEnableTag = CollisionEnableTag;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != CollisionEnableTag || other.tag != "Obstacle") return;

        this.gameObject.SetActive(false);

        if(other.tag == CollisionEnableTag) ApplyDamage(other);
    }

    ApplyDamage(Collider other);
}
