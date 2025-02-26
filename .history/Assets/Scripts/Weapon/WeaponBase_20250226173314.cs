using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public TextAsset csvFile;

    void Start()
    {
        LoadWeapon();
    }

    public void LoadWeapon()
    {
        string[] lines = csvFile.text.Split('\n'); // ✅ 한 줄씩 읽기
        itemDatabase.items.Clear();

        for (int i = 1; i < lines.Length; i++) // ✅ 첫 줄(헤더) 제외
        {
            string[] values = lines[i].Split(',');
            if (values.Length < 3) continue;

            WeaponDataStruct item = new WeaponDataStruct
            {
                WeaponID = int.Parse(values[0]),
                Weaponname = values[1],
                WeaponATK= int.Parse(values[2]),
                WeaponATKSpeed = float.Parse(values[3])
            };
            itemDatabase.items.Add(item);
        }

        Debug.Log("CSV 데이터 로드 완료!");
    }
}
