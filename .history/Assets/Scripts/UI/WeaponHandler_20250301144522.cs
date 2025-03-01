using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{


    [SerializeField] Material EnableColor;
    [SerializeField] Material DisableColor;
    [SerializeField] int WeaponID;
    
    GameObject DisplayingModel;
    WayPoint LastWayPoint;

    PlayerController PC;
    int WeaponCost;
    GameObject WeaponPrefab;
    GameObject WeaponModelPrefab;

    void Start()
    {
        Init();
    }

     void Init()
    {
        PC = FindFirstObjectByType<PlayerController>();
        var weaponData = PC.GetWeaponData[WeaponID];
        WeaponCost = weaponData.Cost;
        WeaponPrefab = Resources.Load<GameObject>(weaponData.WeaponPrefabPath);
        WeaponModelPrefab = Resources.Load<GameObject>(weaponData.WeaponModelPrefabPath);
        
        DisplayingModel = Instantiate(WeaponModelPrefab, transform.position, Quaternion.identity);
        DisplayingModel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PC.CloseLastClickUI();
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
        if(!DisplayingModel.activeInHierarchy) DisplayingModel.SetActive(true);

        DisplayingModel.transform.position = transform.position;
        
        MeshRenderer[] renderers = DisplayingModel.GetComponentsInChildren<MeshRenderer>();

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
            LastWayPoint.SpawnWeapon(WeaponPrefab);
            PC.UpdateGold(-WeaponCost);
        }

        DisplayingModel.SetActive(false);
    }


}
