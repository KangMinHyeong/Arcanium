
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
    bool bCanSpawn = false;
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
            CheckWayPoint(hit.collider.gameObject, hit.point);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckPlaySkill();
    }

    void CheckWayPoint(GameObject obj, Vector3 pos)
    {
        LastWayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!LastWayPoint) return;

        if(!LastWayPoint.IsPlacable)
        {
            DisplaySkill(true, pos);
        }
        else
        {
            DisplaySkill(false, pos);
        }
    }

    void DisplaySkill(bool bInstall, Vector3 pos)
    {
        if(!DisplayingSkill.activeInHierarchy) DisplayingSkill.SetActive(true);

        DisplayingSkill.transform.position = pos;
        bCanSpawn = bInstall;

        Image image = DisplayingSkill.GetComponentInChildren<Image>();
        
        if(bCanSpawn)
        {
            image.color = EnableColor;
        }
        else
        {
            image.color = DisableColor;
        }
    }

    void CheckPlaySkill()
    {

    }
}
