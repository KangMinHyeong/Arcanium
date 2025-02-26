using UnityEngine;
using System.Collections.Generic;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] int WeaponID;

    protected PlayerController PC;
    protected WeaponDataStruct WeaponData;
    protected GameObject WeaponPrefab;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        InitWeaponData();
    }

    void InitWeaponData()
    {
        WeaponData = PC.GetWeaponData.weapons[WeaponID];       
        WeaponPrefab = Resources.Load<GameObject>(WeaponData.WeaponPrefabPath);
    }
}
