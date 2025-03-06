using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public class WeaponDataStruct
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
    public float WeaponRange = 15.0f;

    // behavior
    public bool WeaponRotation = false;
}

[Serializable]
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}

public class WeaponSO1
{
    
}
