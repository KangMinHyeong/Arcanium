using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool bPlcable = false; // Weapon 설치 가능 여부
    [SerializeField] GameObject InstallableUI;

    [SerializeField] Color EnableColor;
    [SerializeField] Color DisableColor;

    bool bInstalled = false; // Weapon이 설치되어있는지 여부
    bool bDrag = false;

    WeaponBase WeaponBase;
    PlayerController PC;
    Vector3 CurrentMousePoint;

    public bool IsPlacable {get {return bPlcable;} set {bPlcable = value;}}

    void Start()
    {
        PC = FindAnyObjectByType<PlayerController>();

        InitInstallableUI();
    }

    void InitInstallableUI()
    {
        var Images = InstallableUI.GetComponentsInChildren<Image>();

        Debug.Log(Images);

        foreach(var Image in Images)
        {
            if(bInstalled)
            {
                Image.color = EnableColor;
            }
            else
            {
                Image.color = DisableColor;
            }
        }
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
        if(bInstalled) return;
        
        if(!bDrag)
        {
            CurrentMousePoint = Input.mousePosition;
            bDrag = true;
        }
        else
        {
            PC.MoveCamera(Input.mousePosition - CurrentMousePoint);
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

    public void InitPlacable() // 해당 타일의 Weapon을 팔았을 때 사용 
    {
        WeaponBase = null;
        bPlcable = true;
        bInstalled = false;
    }

    public void SetActiveInstallable(bool value)
    {
        InstallableUI.SetActive(value);
    }
}
