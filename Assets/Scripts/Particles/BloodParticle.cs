using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    ParticleSystem _bloodParticle;

    void Start()
    {
        _bloodParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(!_bloodParticle.IsAlive()) Destroy(this.gameObject);
    }
}
