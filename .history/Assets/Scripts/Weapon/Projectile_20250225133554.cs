using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 2.5f;
    [SerializeField] string CollisionEnableTag = "";

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * ProjectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != CollisionEnableTag) return;

        Destroy(this.gameObject);
    }
}
