using UnityEngine;

public class Meteor : PlayerSkillBase
{
    protected override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        base.SpawnSkillTrigger(skillData);

        // To Do : Delay
        var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

        foreach(var Other in Others)
        {
            var Enemy = Other.GetComponentInParent<Enemy>();
            if(Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }

    
}
