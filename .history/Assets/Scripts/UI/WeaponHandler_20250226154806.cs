using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] GameObject WeaponModelPrefab;

    [SerializeField] Material EnableColor;
    [SerializeField] Material DisableColor;
    
    GameObject WeaponModel;
    WayPoint LastWayPoint;
    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();

        WeaponModel = Instantiate(WeaponModelPrefab, transform.position, Quaternion.identity);
        WeaponModel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            CheckWayPoint(hit.collider.gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(LastWayPoint)
        {
            LastWayPoint.SpawnWeapon(PC);
        }
        
        WeaponModel.SetActive(false);
    }

    void CheckWayPoint(GameObject obj)
    {
        LastWayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!LastWayPoint) return;

        if(!LastWayPoint.IsPlacable)
        {
            // 붉은 표시
            DisplayWeapon(false, LastWayPoint.transform);
        }
        else
        {
            // 초록 표시
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
}
