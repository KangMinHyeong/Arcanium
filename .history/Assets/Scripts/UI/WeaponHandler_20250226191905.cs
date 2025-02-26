using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] GameObject WeaponModelPrefab;

    [SerializeField] Material EnableColor;
    [SerializeField] Material DisableColor;
    [SerializeField] int WeaponID;
    
    GameObject WeaponModel;
    WayPoint LastWayPoint;
    PlayerController PC;
    int WeaponCost;

    void Start()
    {
        Init();
    }

     void Init()
    {
        PC = FindFirstObjectByType<PlayerController>();
        var weaponData = PC.GetWeaponData.weapons[WeaponID];
        WeaponCost = weaponData.Cost;
        WeaponPrefab = Resources.Load<GameObject>(weaponData.WeaponPrefabPath);
        WeaponModelPrefab = Resources.Load<GameObject>(weaponData.WeaponModelPrefabPath);

        WeaponModel = Instantiate(WeaponModelPrefab, transform.position, Quaternion.identity);
        WeaponModel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (PC.GetPlayerGold < WeaponCost) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            CheckWayPoint(hit.collider.gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckSpawnWeapon();
    }

    void CheckWayPoint(GameObject obj)
    {
        LastWayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!LastWayPoint) return;

        if(!LastWayPoint.IsPlacable)
        {
            DisplayWeapon(false, LastWayPoint.transform);
        }
        else
        {
            DisplayWeapon(true, LastWayPoint.transform);
        }
    }

    void DisplayWeapon(bool bInstall, Transform transform)
    {
        if(!WeaponModel.activeInHierarchy) WeaponModel.SetActive(true);

        WeaponModel.transform.position = transform.position;
        
        MeshRenderer[] renderers = WeaponModel.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in renderers)
        {
            Material[] newMaterials = new Material[renderer.materials.Length]; 
            for (int i = 0; i < newMaterials.Length; i++)
            {
                if(bInstall) {newMaterials[i] = EnableColor;}
                else {newMaterials[i] = DisableColor;}
            }
            renderer.materials = newMaterials;
        }
    }

    void CheckSpawnWeapon()
    {
        if (LastWayPoint && LastWayPoint.IsPlacable)
        {
            LastWayPoint.SpawnWeapon();
            PC.UpdateGold(-WeaponCost);
        }

        WeaponModel.SetActive(false);
    }
}
