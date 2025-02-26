using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct WeaponDataStruct
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
}

[Serializable]
public class WeaponDatabaseWrapper
{
    public List<WeaponDataStruct> weapons;
}

[System.Serializable]
public class WeaponDatabase : ScriptableObject
{
    public List<WeaponDataStruct> weapons = new List<WeaponDataStruct>();
}