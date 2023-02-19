using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    ParticleSystem bloodParticle;

    void Start()
    {
        bloodParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(!bloodParticle.IsAlive()) 
            Destroy(this.gameObject);
    }
}
