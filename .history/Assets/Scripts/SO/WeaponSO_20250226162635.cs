using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct ItemDataStruct
{
    public int id;
    public string name;
    public float attackPower;
}


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemDataStruct> items = new List<ItemDataStruct>();
}