using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyData
{
    public int WaveGroupID;

    public int WaveNum;

    public string EnemyPrefabPath;

    public int EnemyNumber;

    public float WaveRate;

    public float NextWaveTime;
}

[Serializable]
public struct EnemyDatabase
{
    public List<EnemyData> Waves;
}
