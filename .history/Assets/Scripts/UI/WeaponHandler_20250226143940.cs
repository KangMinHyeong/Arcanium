using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] GameObject WeaponModelPrefab;

    [SerializeField] Material EnableColor;
    [SerializeField] Material DisableColor;

    GameObject WeaponModel;
    

    void Start()
    {
        WeaponModel = Instantiate(WeaponModelPrefab, transform.position, Quaternion.identity);
        WeaponModel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("sdf");
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
        // Debug.Log(eventData.lastPress.name.ToString());
    }

    void CheckWayPoint(GameObject obj)
    {
        var wayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!wayPoint) return;

        if(!wayPoint.IsPlacable)
        {
            // 붉은 표시
            DisplayWeapon(false, wayPoint.transform);
        }
        else
        {
            // 초록 표시
            DisplayWeapon(true, wayPoint.transform);
        }
    }

    void DisplayWeapon(bool bInstall, Transform transform)
    {
        if(!WeaponModel.activeInHierarchy) WeaponModel.SetActive(true);

        WeaponModel.transform.position = transform.position;
        
        MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>();

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
