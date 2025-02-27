using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyData
{
    public int EnemyID;

    public string EnemyPrefabPath;

    public int EnemyName;

    public int EnemyHP;

    public float EnemyMoveTime;

    public float EnemyMoveSpeed;
}

[Serializable]
public struct EnemyDatabase
{
    public List<EnemyData> EnemyInfos;
}
