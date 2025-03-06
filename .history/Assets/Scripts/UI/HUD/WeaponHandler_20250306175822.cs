using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject InfoUI;
    [SerializeField] WeaponInfoUI WeaponInfo;
    [SerializeField] Material EnableColor;
    [SerializeField] Material DisableColor;
    [SerializeField] int WeaponID;
    [SerializeField] CanvasGroup HUD;

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
        var weaponData = GameManager.Instance.GetWeaponData[WeaponID];
        WeaponInfo.UpdateWeaponInfo(weaponData);

        WeaponCost = weaponData.Cost;
        WeaponPrefab = Resources.Load<GameObject>(weaponData.WeaponPrefabPath);
        WeaponModelPrefab = Resources.Load<GameObject>(weaponData.WeaponModelPrefabPath);
        
        DisplayingModel = Instantiate(WeaponModelPrefab, transform.position, Quaternion.identity);
        DisplayingModel.GetComponentInChildren<WeaponRange>().SetRange(weaponData.WeaponRotation, weaponData.WeaponRange);
        DisplayingModel.SetActive(false);
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

        transform.root.gameObject.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.root.gameObject.SetActive(true);

        CheckSpawnWeapon();

        PC.DragMove = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InfoUI.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InfoUI.SetActive(false);
    }

    void HideUI()
    {
        HUD.alpha = 0f; // ✅ 투명하게 만들어 숨김
        HUD.blocksRaycasts = false; // ✅ 클릭 이벤트 차단
        HUD.interactable = false; // ✅ 상호작용 비활성화
    }

    void ShowUI()
    {
        HUD.alpha = 1f; // ✅ 다시 보이게 하기
        HUD.blocksRaycasts = true;
        HUD.interactable = true;
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
