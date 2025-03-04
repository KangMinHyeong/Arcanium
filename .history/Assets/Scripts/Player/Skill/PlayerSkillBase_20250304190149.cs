using UnityEngine;
using UnityEngine.VFX;

public class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;
    
    protected virtual void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        // Spawn Effect
        SkillEffect.Play();        
    }
}
