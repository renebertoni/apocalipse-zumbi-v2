using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public static Action EnemyDead;
    ParticleSystem bloodParticle;

    void Start()
    {
        bloodParticle = GetComponent<EnemySettings>().bloodParticle;
    }   

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag(Constants.Get.BULLET))
        {
            EnemyDead?.Invoke();
            var blood = Instantiate(bloodParticle, transform.position, Quaternion.identity);
            blood.Play();
            Destroy(this.gameObject);
        }
    }
}
