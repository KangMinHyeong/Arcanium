using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Meteor : PlayerSkillBase
{
    [SerializeField] int DamageCount = 2;
    [SerializeField] float AttackDelay = 0.75f;

    public override void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        PlayEffect();

        // To Do : Delay
        StartCoroutine(Attack(skillData));
    }

    IEnumerator Attack(PlayerSkillData skillData)
    {
        while(DamageCount != 0)
        {
            var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

            foreach (var Other in Others)
            {
                var Enemy = Other.GetComponentInParent<Enemy>();
                if (Enemy) Enemy.TakeDamage(skillData.SkillDamage);
            }

            yield return new WaitForSeconds(AttackDelay);

            DamageCount--;
        }
    }
}
