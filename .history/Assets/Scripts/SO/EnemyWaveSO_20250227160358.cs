using UnityEngine;
using System;


[Serializable] 
public struct EnemyWave
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
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}
