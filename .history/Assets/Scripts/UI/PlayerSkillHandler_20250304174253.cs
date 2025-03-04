using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSkillHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] float SkillCoolTime;

    PlayerController PC;
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
        if()
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PC.CloseLastClickUI();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (PC.stageGold < WeaponCost)
        {
            PC.DisplayRequireGoldUI();
            return;
        }

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
}
