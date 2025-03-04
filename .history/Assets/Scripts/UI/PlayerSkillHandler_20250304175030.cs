
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerSkillHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] Color EnableColor;
    [SerializeField] Color DisableColor;
    [SerializeField] float SkillCoolTime;

    PlayerController PC;
    WayPoint LastWayPoint;
    GameObject DisplayingSkill;

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
            DisplaySkill(true, LastWayPoint.transform);
        }
        else
        {
            DisplaySkill(false, LastWayPoint.transform);
        }
    }

    void DisplaySkill(bool bInstall, Transform transform)
    {
        if(!DisplayingSkill.activeInHierarchy) DisplayingSkill.SetActive(true);

        DisplayingSkill.transform.position = transform.position;
        
        Image image = DisplayingSkill.GetComponentInChildren<Image>();

        if(bInstall)
        {
            image.color = EnableColor;
        }
        else
        {
            image.color = DisableColor;
        }
    }
}
