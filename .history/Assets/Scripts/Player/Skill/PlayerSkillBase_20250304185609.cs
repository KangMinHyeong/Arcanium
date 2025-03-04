using UnityEngine;

public class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;

    void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        // Spawn Effect
        SkillEffect.Play();
        
        // To Do : Delay
        var Others = Physics.OverlapSphere(transform.position, skillData.SkillRange);

        foreach(var Other in Others)
        {
            var Enemy = Other.GetComponentInParent<Enemy>();
            if(Enemy) Enemy.TakeDamage(skillData.SkillDamage);
        }
    }
}
