using UnityEngine;
using System.Collections.Generic;

public class WeaponBase : MonoBehaviour
{
    protected PlayerController PC;
    [SerializeField] WeaponDatabase weaponDatabase ;

    void Awake()
    {
        weaponDatabase = ScriptableObject.CreateInstance<WeaponDatabase>(); // ✅ 올바른 방식
    
    }

    protected virtual void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();
        LoadWeapon();
    }

    public void LoadWeapon()
    {
        string[] lines = PC.GetWeaponDataTable.text.Split('\n'); // ✅ 한 줄씩 읽기
        if(weaponDatabase) weaponDatabase.weapons.Clear();

        int fieldCount = typeof(WeaponDataStruct).GetProperties().Length; // ✅ 프로퍼티 개수 가져오기
        
        for (int i = 1; i < lines.Length; i++) // ✅ 첫 줄(헤더) 제외
        {
            string[] values = lines[i].Split(',');
            if (values.Length < fieldCount) continue;

            WeaponDataStruct weapon = new WeaponDataStruct
            {
                WeaponID = int.Parse(values[0]),
                Weaponname = values[1],
                WeaponATK= int.Parse(values[2]),
                WeaponATKSpeed = float.Parse(values[3])
            };

            weaponDatabase.weapons.Add(weapon.WeaponID, weapon);
        }

        
        Debug.Log("CSV 데이터 로드 완료!" + weaponDatabase.weapons[0].WeaponATK.ToString());
    }
}
