using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Meteor : PlayerSkillBase
{
    [SerializeField] int DamageCount = 2;
    [SerializeField] float AttackDelay = 1.0f;

    public override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        PlayEffect();

        // To Do : Delay
        
    }

    IEnumerator Attack(PlayerSkillData skillData)
    {
        while(DamageCount != 0)
        {
            yield return new WaitForSeconds(AttackDelay);

            var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

            foreach (var Other in Others)
            {
                var Enemy = Other.GetComponentInParent<Enemy>();
                if (Enemy) Enemy.TakeDamage(skillData.SkillDamage);
            }

            DamageCount--;
        }
    }
}
