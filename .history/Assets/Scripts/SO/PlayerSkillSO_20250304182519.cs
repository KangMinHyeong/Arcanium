using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public class PlayerSkillSO
{
    public int SkillID;

    public string SkillName;

    public float SkillRange = 5.0f;
    public float SkillCoolTime = 5.0f;
}

[Serializable]
public struct EnemyWaveDatabase
{
    public List<EnemyWaveData> Waves;
}