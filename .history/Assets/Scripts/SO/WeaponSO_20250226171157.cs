using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct WeaponDataStruct
{
    public int WeaponID;
    public string Weaponname;
    public int WeaponATK;
}


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<WeaponDataStruct> items = new List<WeaponDataStruct>();
}