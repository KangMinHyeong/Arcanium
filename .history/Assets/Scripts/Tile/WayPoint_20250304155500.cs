using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool bPlcable = false;
    
    bool bInstalled = false;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    
    WeaponBase WeaponBase;

    public void InitPlacable()
    {
        WeaponBase = null;
        bPlcable = true;
        bInstalled = false;
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(bInstalled)
        {
            WeaponBase.OpenWeaponUI();
        }
    }

    public void SpawnWeapon(GameObject WeaponPrefab)
    {
        var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
        if (Weapon) 
        {
            WeaponBase = Weapon.GetComponentInChildren<WeaponBase>();
            WeaponBase.SetWayPoint(this);

            bPlcable = false;
            bInstalled = true;
        }
    }
}
