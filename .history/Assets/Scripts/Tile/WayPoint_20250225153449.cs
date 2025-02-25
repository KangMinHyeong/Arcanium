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
        string df = transform.ToString();
        Debug.Log("transform");
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
