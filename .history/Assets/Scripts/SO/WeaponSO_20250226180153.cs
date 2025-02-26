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


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game Data/Item Database")]
public class WeaponDatabase : ScriptableObject
{
    public Dictionary<int, WeaponDataStruct> items = new Dictionary<int, WeaponDataStruct>();
}