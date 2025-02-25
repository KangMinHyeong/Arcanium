using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool isPlcable = false;

    void OnMouseDown()
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        if (isPlcable)
        {
            var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (Weapon) isPlcable = false;
        }
    }
}
