using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyWave
{
    public int WaveGroupID;

    public int WaveNum;

    public string EnemyPrefabPath;

    public int EnemyNumber;

    public float NextWaveTime;
}

[Serializable]
public struct EnemyWavebase
{
    public List<EnemyWave> Waves;
}
