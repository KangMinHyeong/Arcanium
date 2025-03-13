using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct StageData
{
    public int StageID; // Dictionary의 키값이 될 Stage Index

    public int StageGold; // Stage 기본 시작 Gold
    public int StageHP; // Stage 기본 시작 HP
}

[Serializable]
public struct StageDatabase
{
    public List<StageData> Stages;
}
