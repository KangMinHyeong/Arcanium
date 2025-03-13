using UnityEngine;
using UnityEngine.VFX;

public class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;
    
    public virtual void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        // Spawn Effect
        SkillEffect.Play();   
        AttackTrigger(skillData);    
    }

    protected virtual void AttackTrigger(PlayerSkillData skillData)
    {
    }
}
