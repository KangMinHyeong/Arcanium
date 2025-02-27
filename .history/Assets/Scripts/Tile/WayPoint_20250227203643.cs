using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool bPlcable = false;
    
    bool bInstalled = true;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    

    void OnMouseDown()
    {
        if(bInstalled)
        {
            // To Do : 강화
            // To Da : 판매매
        }
    }

    public void SpawnWeapon()
    {
        var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
        if (Weapon) 
        {
            bPlcable = false;
            bInstalled = true;
        }
        // if (bPlcable)
        // {
        //     var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
        //     if (Weapon) 
        //     {
        //         bPlcable = false;
        //         bInstalled = true;
        //     }
        // }
    }
}
