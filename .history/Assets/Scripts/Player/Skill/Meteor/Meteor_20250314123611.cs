using System.Collections;
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
            var Enemy = Other.GetComponentInParent<Enemy>();
            if (Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }

    IEnumerator Attack()
    {
        yield return null;
    }
}
