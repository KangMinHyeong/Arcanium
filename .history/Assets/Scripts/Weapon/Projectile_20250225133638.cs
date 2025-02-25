using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    [SerializeField] string CollisionEnableTag = "";

    Rigidbody rb;
    int DamageAmount;

    public void Init(int DamageAmount)
    {
        this.DamageAmount = DamageAmount;

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * ProjectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != CollisionEnableTag) return;

        Destroy(this.gameObject);
    }
}
