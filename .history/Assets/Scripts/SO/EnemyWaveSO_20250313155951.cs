using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyWaveData
{
    public int WaveGroupID; // Wave 그룹 Index = 스테이지 Index

    public int WaveNum;

    public int EnemyID;

    public int EnemyNumber;

    public float WaveRate;

    public float NextWaveTime;
}

[Serializable]
public struct EnemyWaveDatabase
{
    public List<EnemyWaveData> Waves;
}
