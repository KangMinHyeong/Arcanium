using UnityEngine;

public class PlayerSkillBase : MonoBehaviour
{
    int Damage;
    float Range;

    void SpawnSkillTrigger(int Damage, float Range)
    {
        this.Damage = Damage;
        this.Range = Range;

        
    }
}
