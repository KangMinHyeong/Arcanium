using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable] 
public struct WeaponDataStruct
{
    public int WeaponID; // Dictionary의 키값이 될 Weapon Index

    public string Weaponname; 
    public string WeaponType;
    public string WeaponInformation;

    public string WeaponPrefabPath; // Load할 Weapon Prefab 경로
    public string WeaponModelPrefabPath; // 설치 경로로 보여줄 Model Prefab 경로
    public string HitVFXPath;

    // Cost
    public int Cost;
    public int EnhanceCostLevel_2;
    public int EnhanceCostLevel_3;

    // Attack
    public int WeaponATK;
    public float WeaponATKSpeed;
    public float WeaponRange;

    // behavior
    public bool WeaponRotation;
}

[Serializable]
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}

public class WeaponSO1
{
    
}
