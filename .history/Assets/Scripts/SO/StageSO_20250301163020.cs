using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct StageData
{
    public int WaveGroupID;

    public int WaveNum;

    public int EnemyID;

    public int EnemyNumber;

    public float WaveRate;

    public float NextWaveTime;
}

[Serializable]
public struct StageDatabase
{
    public List<StageData> Waves;
}
