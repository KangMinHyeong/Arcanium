using UnityEngine;

using System;
using System.Collections.Generic;

[Serializable] 
public struct PlayerData
{
    public int PlayerID;

    public string PlayerName;

    // Attack
    public int PlayerATK;
    public float PlayerATKCoefficient;
    public float PlayerATKSpeed;
}
