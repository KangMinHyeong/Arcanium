using UnityEngine;

public class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;
    [SerializeField] ParticleSystem SkillEffect;

    void SpawnSkillTrigger(PlayerSkillData skillData)
    {
        // Spawn Effect
        SkillEffect.Play();
        
        // To Do : Delay
        Physics.OverlapSphere(transform.position, )
    }
}
