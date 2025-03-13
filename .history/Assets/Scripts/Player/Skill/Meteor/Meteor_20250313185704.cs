using UnityEngine;
using UnityEngine.VFX;

public class Meteor : PlayerSkillBase
{
    public override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        PlayEffect();

        // To Do : Delay
        var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

        foreach (var Other in Others)
        {
            Debug.Log(Other.transform.name);
            var Enemy = Other.GetComponentInParent<Enemy>();
            if (Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }
}
