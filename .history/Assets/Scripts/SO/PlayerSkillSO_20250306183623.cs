using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct PlayerSkillData
{
    public int SkillID;

    public string SkillName;
    public string SkillPrefabPath;

    // Attack
    public int SkillDamage;
    public float SkillRange;
    public float SkillCoolTime;
}

[Serializable]
public struct PlayerSkillDatabase
{
    public List<PlayerSkillData> Skills;
}