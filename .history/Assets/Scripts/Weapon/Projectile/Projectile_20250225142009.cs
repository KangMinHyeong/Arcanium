using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    [SerializeField] string CollisionEnableTag = "";

    Rigidbody rb;
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

    public void Init(int DamageAmount)
    {
        this.DamageAmount = DamageAmount;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != CollisionEnableTag) return;

        Destroy(this.gameObject);
    }
}
