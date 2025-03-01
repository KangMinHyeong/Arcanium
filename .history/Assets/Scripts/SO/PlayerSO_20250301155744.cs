using UnityEngine;

using System;
using System.Collections.Generic;

[Serializable] 
public class PlayerData
{
    public int PlayerID;

    public string PlayerName;

    // Attack
    public int PlayerATK = 0;
    public float PlayerATKCoefficient = 1.0f;
    public float PlayerATKSpeed = 1.0f;
}
