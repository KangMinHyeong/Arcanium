using System.Collections.Generic;
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

    bool bHide = false;
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

        if (PC.stageGold < WeaponCost) // 현재 골드가 Weapon Cost보다 많은 지 체크
        {
            PC.DisplayRequireGoldUI(); // 아니라면 골드 부족 메세지를 재생하고 얼리 리턴
            return;
        }

        HideUI(true); // HUD 비활성화

        // Raycast로 Weapon 설치 가능한 타일 체크
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

        PC.DragMove = true;
        HideUI(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InfoUI.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InfoUI.SetActive(false);
    }

    void HideUI(bool Hide)
    {        
        bHide = Hide;

        if(bHide) // HUD 비활성화
        {
            HUD.alpha = 0f;
            HUD.blocksRaycasts = false;
            HUD.interactable = false; 
        }
        else // HUD 활성화
        {
            HUD.alpha = 1.0f;
            HUD.blocksRaycasts = true;
            HUD.interactable = true; 
        }

        WayPoint[] waypoints = FindObjectsByType<WayPoint>(FindObjectsSortMode.None);
        foreach(var waypoint in waypoints) 
        {
            waypoint.SetActiveInstallable(bHide);
        }
    }

    void CheckWayPoint(GameObject obj)
    {
        // Raycast로 감지된 GameObject가 WayPoint 타일인지 체크
        LastWayPoint = obj.GetComponentInChildren<WayPoint>(); 
        if(!LastWayPoint) return;
        
        if(LastWayPoint.IsPlacable) // WayPoint 타일이 설치가능한 타일인 지 체크
        {
            DisplayWeapon(true, LastWayPoint.transform); // 설치 가능하다면 true 머터리얼
        }
        else 
        {
            DisplayWeapon(false, LastWayPoint.transform); // 설치 불가능하다면 false 머터리얼
        }
    }

    void DisplayWeapon(bool bInstall, Transform transform)
    {
        // 미리 스폰 후 비활성화 해둔 Weapon Modeling을 활성화
        if(!DisplayingModel.activeInHierarchy) DisplayingModel.SetActive(true);

        // Weapon Modeling의 위치를 마우스가 위치해 있는 Waypoint 타일 위치로 동기화
        DisplayingModel.transform.position = transform.position;
        
        // Weapon Modeling의 모든 메쉬 렌더를 가져오고 각 메쉬 렌더의 머터리얼을 변경
        MeshRenderer[] renderers = DisplayingModel.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            Material[] newMaterials = new Material[renderer.materials.Length]; 
            for (int i = 0; i < newMaterials.Length; i++)
            {
                if(bInstall) {newMaterials[i] = EnableColor;} // 설치 가능한 곳이면 Green 머터리얼로 표시
                else {newMaterials[i] = DisableColor;} // 설치 가능한 곳이면 Red 머터리얼로 표시
            }
            renderer.materials = newMaterials; // 해당하는 머터리얼로 할당
        }
    }
    
}
