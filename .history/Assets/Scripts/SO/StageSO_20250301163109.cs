using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct StageData
{
    public int StageID;

    public int StageGold;
    public int StageHP;
}

[Serializable]
public struct StageDatabase
{
    public List<StageData> Stages;
}
