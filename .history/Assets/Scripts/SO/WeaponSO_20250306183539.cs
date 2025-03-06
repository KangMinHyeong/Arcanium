using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct WeaponDataStruct
{
    public int WeaponID;

    public string Weaponname;
    public string WeaponType;
    public string WeaponInformation;

    public string WeaponPrefabPath;
    public string WeaponModelPrefabPath;

    // Cost
    public int Cost;
    public int EnhanceCostLevel_2;
    public int EnhanceCostLevel_3;

    // Attack
    public int WeaponATK;
    public float WeaponATKSpeed;
    public float WeaponRange;

    // behavior
    public bool WeaponRotation;
}

[Serializable]
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}

public class WeaponSO1
{
    
}
