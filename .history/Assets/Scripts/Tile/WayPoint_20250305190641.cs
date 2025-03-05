using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool bPlcable = false;
    
    bool bInstalled = false;
    bool bDrag = false;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}
    
    WeaponBase WeaponBase;
    PlayerController PC;
    Vector3 CurrentMousePoint;

    void Start()
    {
        PC = FindAnyObjectByType<PlayerController>();
    }
    public void InitPlacable()
    {
        WeaponBase = null;
        bPlcable = true;
        bInstalled = false;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(bInstalled)
        {
            WeaponBase.OpenWeaponUI();
        }
        else
        {
            PC.CloseLastClickUI();
        }
    }

    void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(!bDrag)
        {
            CurrentMousePoint = Input.mousePosition;
            bDrag = true;
        }
        else
        {
            PC.MoveCamera(Input.mousePosition - CurrentMousePoint);
            Debug.Log(Input.mousePosition - CurrentMousePoint);
            CurrentMousePoint = Input.mousePosition;
        }
    }

    void OnMouseUp()
    {
        bDrag = false;
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
