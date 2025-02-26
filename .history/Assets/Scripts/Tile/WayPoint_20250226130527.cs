using UnityEngine;
using UnityEngine.EventSystems;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] bool isPlcable = false;
    [SerializeField] int WeaponCost = 20;

    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
    }
    
    void OnMouseOver()
    {
        
    }

    void OnMouseDown()
    {
         if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭 감지
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SpawnWeapon();
            }
        }
        // 
    }

    void SpawnWeapon()
    {
        if (isPlcable && PC.GetPlayerGold >= WeaponCost)
        {
            var Weapon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (Weapon) 
            {
                isPlcable = false;
                PC.UpdateGold(-WeaponCost);
            }
        }
    }
}
