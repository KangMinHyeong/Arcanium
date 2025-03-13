using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyWaveData
{
    public int WaveGroupID; // Wave 그룹 Index == 스테이지 Index

    public int WaveNum; // Wave 번호

    public int EnemyID; // 스폰할 Enemy Index

    public int EnemyNumber; // 스폰할 Enemy 숫자

    public float WaveRate; // 한 웨이브 마다 Enemy 스폰 간격

    public float NextWaveTime; // 다음 웨이브까지 남은 시간
}

[Serializable]
public struct EnemyWaveDatabase
{
    public List<EnemyWaveData> Waves;
}
