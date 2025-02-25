using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    [SerializeField] string CollisionEnableTag = "";

    Rigidbody rb;
    int DamageAmount;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * ProjectileSpeed;
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
