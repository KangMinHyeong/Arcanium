using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct StageData
{
    public int WaveGroupID;

    public int WaveNum;

    public int StageGold;
    public int StageHP;
}

[Serializable]
public struct StageDatabase
{
    public List<StageData> Stages;
}
