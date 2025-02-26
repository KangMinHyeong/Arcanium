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


[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Game Data/Item Database")]
public class WeaponDatabase : ScriptableObject
{
    public List<WeaponDataStruct> weapons = new List<WeaponDataStruct>();
}