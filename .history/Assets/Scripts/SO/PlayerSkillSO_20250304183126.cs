using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public class PlayerSkillData
{
    public int SkillID;

    public string SkillName;

    // Attack
    public float SkillCoolTime = 5.0f;
    public float SkillRange = 5.0f;
    public float SkillCoolTime = 5.0f;
}

[Serializable]
public struct PlayerSkillDatabase
{
    public List<PlayerSkillData> Skills;
}