using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public class WeaponDataStruct
{
    public int WeaponID;

    public string Weaponname;

    public string WeaponPrefabPath;
    public string WeaponModelPrefabPath;

    // Cost
    public int Cost;

    // Attack
    public int WeaponATK;
    public float WeaponATKSpeed;
    public float WeaponRange = 1500.0f;
}

[Serializable]
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}

public class WeaponSO1
{
    
}
