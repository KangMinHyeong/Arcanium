using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyData
{
    public int EnemyID;

    public int EnemyName;

    public int EnemyHP;

    public int HP;

    public int WaveNum;

    public string EnemyPrefabPath;

    public int EnemyNumber;

    public float WaveRate;

    public float NextWaveTime;
}

[Serializable]
public struct EnemyDatabase
{
    public List<EnemyData> EnemyDatas;
}
