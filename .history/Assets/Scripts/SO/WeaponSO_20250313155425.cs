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
    public string HitVFXPath; // 공격에 히트 시 인스턴스 스폰할 Hit 파티클 경로

    // Cost
    public int Cost; // 기본 Weapon Cost
    public int EnhanceCostLevel_2; // 2레벨로 강화하는데 필요한 Cost
    public int EnhanceCostLevel_3; // 3레벨로 강화하는데 필요한 Cost

    // Attack
    public int WeaponATK; // Weapon 기본 공격력
    public float WeaponATKSpeed; // Weapon 기본 공격속도
    public float WeaponRange;// Weapon 기본 공격범위

    // behavior
    public bool WeaponRotation; // Weapon이 회전 가능여부
}

[Serializable]
public struct WeaponDatabase
{
    public List<WeaponDataStruct> weapons;
}

public class WeaponSO1
{
    
}
