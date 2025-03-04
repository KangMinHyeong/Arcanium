using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSkillHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] float SkillCoolTime;

    PlayerController PC;
    WayPoint LastWayPoint;

    bool bCanUse = true;
    float CurrentCoolTime;
    

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        if(bCanUse) return;

        CurrentCoolTime += Time.deltaTime;
        if(CurrentCoolTime >= SkillCoolTime)
        {
            bCanUse = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PC.CloseLastClickUI();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        PC.CloseLastClickUI();
        if (!bCanUse) return;

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
            DisplaySkill(false, LastWayPoint.transform);
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
}
