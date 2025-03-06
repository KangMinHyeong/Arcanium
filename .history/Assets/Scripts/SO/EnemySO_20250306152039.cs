using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyData
{
    public int EnemyID;

    public string EnemyInformation;
    
    public string EnemyPrefabPath;

    public int EnemyName;

    // Status Data
    public int EnemyHP;

    public float EnemyMoveTime;

    public float EnemyMoveSpeed;

    // Award Data
    public int EnemyGold;
}

[Serializable]
public struct EnemyDatabase
{
    public List<EnemyData> EnemyInfos;
}
