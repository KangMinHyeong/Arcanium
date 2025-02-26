using UnityEngine;
using System.Collections.Generic;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] WeaponDatabase weaponDatabase ;

    protected PlayerController PC;
    protected WeaponDataStruct WeaponData;

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        InitWeaponData();
    }

    void InitWeaponData()
    {

    }
}
