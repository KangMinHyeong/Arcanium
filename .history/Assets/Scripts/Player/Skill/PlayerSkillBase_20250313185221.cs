using UnityEngine;
using UnityEngine.VFX;

public abstract class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;
    
    public abstract void SpawnSkillTrigger(PlayerSkillData skillData)
    { 
    }

    protected void PlayEffect()
    {
        SkillEffect.Play();  
    }

    protected virtual void AttackTrigger(PlayerSkillData skillData)
    {
    }
}
