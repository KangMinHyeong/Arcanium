using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct WeaponDataStruct
{
    public int WeaponID;
    public string Weaponname;
    public int WeaponATK;
    public float WeaponATKSpeed;
}


[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Game Data/Item Database")]
public class WeaponDatabase : ScriptableObject
{
    public Dictionary<int, WeaponDataStruct> weapons = new Dictionary<int, WeaponDataStruct>();
}