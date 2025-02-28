using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool bPlcable = false;
    
    bool bInstalled = false;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    
    GameObject Weapon;

    void OnMouseDown()
    {
        if(bInstalled)
        {
            Weapon.GetComponentInChildren<WeaponBase>().OpenWeaponUI();
            // To Do : 강화
            // To Da : 판매매
        }
    }

    public void SpawnWeapon(GameObject WeaponPrefab)
    {
        Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
        if (Weapon) 
        {
            bPlcable = false;
            bInstalled = true;
        }
    }
}
