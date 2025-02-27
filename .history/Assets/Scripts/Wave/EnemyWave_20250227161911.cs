using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] TextAsset WaveDataTable;

    void Start()
    {
        Init();
    }

    void Init()
    {
        EnemyWaveDatabase Wrapper  = JsonUtility.FromJson<EnemyWaveDatabase>(WaveDataTable.text);
        
        foreach (var weapon in Wrapper.weapons)
        {
            WeaponDatabase[weapon.WeaponID] = weapon;
        }
    }
}
