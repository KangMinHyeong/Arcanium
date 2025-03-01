using UnityEngine;

using System;
using System.Collections.Generic;

[Serializable] 
public struct PlayerData
{
    public int WeaponID;

    public string Weaponname;

    public string WeaponPrefabPath;
    public string WeaponModelPrefabPath;

    // Cost
    public int Cost;

    // Attack
    public int WeaponATK;
    public float WeaponATKSpeed;
}
