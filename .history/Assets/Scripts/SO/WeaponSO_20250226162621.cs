using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct ItemDataStruct
{
    int id;
    string name;
    float attackPower;
}


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemDataStruct> items = new List<ItemDataStruct>();
}