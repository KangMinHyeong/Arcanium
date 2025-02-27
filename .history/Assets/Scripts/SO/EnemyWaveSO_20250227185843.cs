using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyWaveData
{
    public int WaveGroupID;

    public int WaveNum;

    public int EnemyID;

    public string EnemyPrefabPath;

    public int EnemyNumber;

    public float WaveRate;

    public float NextWaveTime;
}

[Serializable]
public struct EnemyWaveDatabase
{
    public List<EnemyWaveData> Waves;
}
