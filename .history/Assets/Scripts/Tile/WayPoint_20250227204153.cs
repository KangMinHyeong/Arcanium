using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool bPlcable = false;
    
    [SerializeField] bool bInstalled = false;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    

    void OnMouseDown()
    {
        if(bInstalled)
        {
            Debug.Log("bInstalled");
            // To Do : 강화
            // To Da : 판매매
        }
    }

    public void SpawnWeapon(GameObject WeaponPrefab)
    {
        var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
        if (Weapon) 
        {
            bPlcable = false;
            bInstalled = true;
        }
    }
}
