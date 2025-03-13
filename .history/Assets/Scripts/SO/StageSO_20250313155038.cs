using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct StageData
{
    public int StageID; // Dictionary의 키값이 될 Stage Index

    public int StageGold; // Dictionary의 키값이 될 Stage Gold
    public int StageHP; // Dictionary의 키값이 될 Stage HP
}

[Serializable]
public struct StageDatabase
{
    public List<StageData> Stages;
}
