
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

        // Skill Data 초기화
        SkillData = GameManager.Instance.GetSkillData[SkillID];
        // Instantiate로 스폰할 SkillPrefab 리소스 로드
        SkillPrefab = Resources.Load<GameObject>(SkillData.SkillPrefabPath);

        // 스킬 쿨타임 퍼센트 0초로 초기화
        SkillPercentImage.fillAmount = 0.0f;

        // 스킬 범위 표시 오브젝트 스폰 후 비활성화
        DisplayingSkill = Instantiate(DisplayingSkillPrefab, transform.position, Quaternion.identity);
        DisplayingSkill.GetComponentInChildren<WeaponRange>().SetRange(true, SkillData.SkillRange);
        DisplayingSkill.SetActive(false);
    }

    void Update()
    {
        // 스킬이 사용 가능하면 쿨타임 표시 X
        if(bCanUse) return;

        CurrentCoolTime += Time.deltaTime;
        
        if(CurrentCoolTime < SkillData.SkillCoolTime) // 스킬이 쿨타임 중이면 fillAmount 값을 업데이트
        {
            SkillPercentImage.fillAmount = (SkillData.SkillCoolTime - CurrentCoolTime) / SkillData.SkillCoolTime;
        }
        else // 스킬이 쿨타임이 완료되면 스킬 가능 활성화
        {
            SkillPercentImage.fillAmount = 0.0f;
            CurrentCoolTime = 0.0f;
            bCanUse = true;
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
        PC.DragMove = false;

        if (!bCanUse) return; // 스킬을 사용할 수 있는 지 체크

        // Raycast로 Skill 사용 가능한 구역 체크
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            CheckWayPoint(hit.collider.gameObject, hit.point);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 스킬 가능 여부 체크 함수 호출
        CheckSpawnSkill();

        PC.DragMove = true;
    }

    void CheckSpawnSkill() // 스킬 가능 여부 체크 함수
    {
        if(bCanSpawn && bCanUse)
        {
            // 스킬 인스턴스 스폰 후 스킬 Data 초기화
            var Skill = Instantiate(SkillPrefab, DisplayingSkill.transform.position, Quaternion.identity);
            Skill.GetComponent<PlayerSkillBase>().SpawnSkillTrigger(SkillData);
            bCanUse = false;
        }

        DisplayingSkill.SetActive(false);
    }

    void CheckWayPoint(GameObject obj, Vector3 pos)
    {
        LastWayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!LastWayPoint) return;

        if(!LastWayPoint.IsPlacable) 
        {
            DisplaySkill(true, pos); // 스킬 가능 구역이면 true
        }
        else 
        {
            DisplaySkill(false, pos); // 스킬 가능 구역이면 true
        }
    }

    void DisplaySkill(bool bInstall, Vector3 pos)
    {
        if(!DisplayingSkill.activeInHierarchy) DisplayingSkill.SetActive(true);

        // 스킬 범위 이미지를 Raycast의 히트 포인트로 할당
        DisplayingSkill.transform.position = pos;
        // 스킬을 사용 가능 여부 변수를 동기화
        bCanSpawn = bInstall;

        Image image = DisplayingSkill.GetComponentInChildren<Image>();
        
        if(bCanSpawn) image.color = EnableColor; // 사용 가능 컬러로 변경
        else image.color = DisableColor; // 사용 가능 컬러로 변경
    }
}
