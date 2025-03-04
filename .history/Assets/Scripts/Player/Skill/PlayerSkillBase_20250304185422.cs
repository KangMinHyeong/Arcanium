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
    }
}
