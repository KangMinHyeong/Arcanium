using UnityEngine;

using System;
using System.Collections.Generic;

[Serializable] 
public struct PlayerData
{
    public int PlayerID;

    public string Playername;

    // Attack
    public int PlayerATK;
    public float PlayerATKSpeed;
}
