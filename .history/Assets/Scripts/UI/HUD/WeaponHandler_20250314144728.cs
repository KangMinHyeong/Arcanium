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

        HideUI(); // HUD 비활성화화

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
        ShowUI();
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
        if(bHide) return;
        
        bHide = true;
        HUD.alpha = 0f; 
        HUD.blocksRaycasts = false;
        HUD.interactable = false; 


        WayPoint[] waypoints = FindObjectsByType<WayPoint>(FindObjectsSortMode.None);
        foreach(var waypoint in waypoints) 
        {
            waypoint.SetActiveInstallable(true);
        }
    }

    void ShowUI()
    {
        bHide = false;
        HUD.alpha = 1f; 
        HUD.blocksRaycasts = true;
        HUD.interactable = true;

        WayPoint[] waypoints = FindObjectsByType<WayPoint>(FindObjectsSortMode.None);
        foreach(var waypoint in waypoints) 
        {
            waypoint.SetActiveInstallable(false);
        }
    }

    void CheckWayPoint(GameObject obj)
    {
        // Raycast로 감지된 GameObject가 WayPoint 타일인지 체크크
        LastWayPoint = obj.GetComponentInChildren<WayPoint>(); 
        if(!LastWayPoint) return;
        
        if(LastWayPoint.IsPlacable) // WayPoint 타일이 
        {
            DisplayWeapon(true, LastWayPoint.transform);
        }
        else 
        {
            DisplayWeapon(false, LastWayPoint.transform);
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
        if (PC.stageGold >= WeaponCost && LastWayPoint && LastWayPoint.IsPlacable)
        {
            LastWayPoint.SpawnWeapon(WeaponPrefab);
            PC.UpdateGold(-WeaponCost);
        }

        DisplayingModel.SetActive(false);
    }

    
}
