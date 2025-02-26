using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool isPlcable = false;
    [SerializeField] int WeaponCost = 20;

    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }
    
    void OnMouseOver()
    {
        Debug.Log("saff");
    }

    void OnMouseDown()
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        if (isPlcable && PC.GetPlayerGold >= WeaponCost)
        {
            var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (Weapon) 
            {
                isPlcable = false;
                PC.UpdateGold(-WeaponCost);
            }
        }
    }
}
