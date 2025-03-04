using UnityEngine;
using UnityEngine.VFX;

public class Meteor : PlayerSkillBase
{
    [SerializeField] VisualEffect MeteorEffect;

    protected override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        MeteorEffect.Play();

        // To Do : Delay
        var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

        foreach(var Other in Others)
        {
            var Enemy = Other.GetComponentInParent<Enemy>();
            if(Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }

    
}
