using UnityEngine;

public class PlayerSkillBase : MonoBehaviour
{
    [SerializeField] ParticleSystem SkillEffect;

    void SpawnSkillTrigger(int Damage, float Range)
    {
        // Spawn Effect
        SkillEffect.Play();
        
        Physics.OverlapSphere(transform.position, )
    }
}
