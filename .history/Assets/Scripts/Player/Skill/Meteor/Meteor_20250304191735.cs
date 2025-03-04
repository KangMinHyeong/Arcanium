using UnityEngine;
using UnityEngine.VFX;

public class Meteor : PlayerSkillBase
{
    [SerializeField] VisualEffect MeteorVFX;

    public override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        // MeteorVFX.Play();

        // To Do : Delay
        var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange * 10.0f);

        foreach(var Other in Others)
        {
            Debug.Log(Other.transform.name);
            var Enemy = Other.GetComponentInParent<Enemy>();
            if(Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }

    
}
