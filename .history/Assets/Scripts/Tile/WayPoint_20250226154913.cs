using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool bPlcable = false;
    [SerializeField] int WeaponCost = 20;

    bool bInstalled = true;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    

    void OnMouseDown()
    {
    }

    public void SpawnWeapon(PlayerController PC)
    {
        if (bPlcable)
        {
            var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (Weapon) 
            {
                bPlcable = false;
                bInstalled = true;
                PC.UpdateGold(-WeaponCost);
            }
        }
    }
}
