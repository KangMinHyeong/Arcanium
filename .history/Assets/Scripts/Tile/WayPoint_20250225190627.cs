using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool isPlcable = false;
    [SerializeField] int WeaponGold = 20;

    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }

    void OnMouseDown()
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        if (isPlcable && PC.GetPlayerGold >= WeaponGold)
        {
            var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (Weapon) 
            {

            }
        }
    }
}
