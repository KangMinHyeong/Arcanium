
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerSkillHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] GameObject DisplayingSkillPrefab;
    [SerializeField] Image SkillPercentImage;
    [SerializeField] Color EnableColor;
    [SerializeField] Color DisableColor;
    [SerializeField] int SkillID = 0;
    // [SerializeField] float SkillCoolTime = 4.0f;
    // [SerializeField] float SkillRange = 10.0f;
    
    PlayerSkillData SkillData;
    PlayerController PC;
    WayPoint LastWayPoint;
    GameObject DisplayingSkill;
    GameObject SkillPrefab;

    bool bCanUse = true;
    bool bCanSpawn = false;
    float CurrentCoolTime;
    
    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        SkillData = GameManager.Instance.GetSkillData[SkillID];

        SkillPrefab = Resources.Load<GameObject>(SkillData.SkillPrefabPath);

        DisplayingSkill = Instantiate(DisplayingSkillPrefab, transform.position, Quaternion.identity);
        DisplayingSkill.GetComponentInChildren<WeaponRange>().SetRange(true, SkillData.SkillRange);
        DisplayingSkill.SetActive(false);
    }

    void Update()
    {
        if(bCanUse) return;

        CurrentCoolTime += Time.deltaTime;
        if(CurrentCoolTime >= SkillData.SkillCoolTime)
        {
            CurrentCoolTime = 0.0f;
            bCanUse = true;
        }

        SkillPercentImage.fillAmount = CurrentCoolTime / SkillData.SkillCoolTime;
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
        CheckSpawnSkill();
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

    void CheckSpawnSkill()
    {
        if(bCanSpawn && bCanUse)
        {
            // SpawnSkill
            var Skill = Instantiate(SkillPrefab, DisplayingSkill.transform.position, Quaternion.identity);
            Skill.GetComponent<PlayerSkillBase>().SpawnSkillTrigger(SkillData);
            bCanUse = false;
        }

        DisplayingSkill.SetActive(false);
    }
}
