using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct EnemyWave
{
    public int WaveID;

    public int WaveGroupID;

    public string WeaponPrefabPath;
    public string WeaponModelPrefabPath;

    // Cost
    public int Cost;

    // Attack
    public int WeaponATK;
    public float WeaponATKSpeed;
}

[Serializable]
public struct EnemyWavebase
{
    public List<EnemyWave> Waves;
}
