using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool isPlcable = false;

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        SpawnWeapon();
    }

    void OnMouseOver() 
    {
        Debug.Log("OnMouseDown");
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
