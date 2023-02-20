using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    public ParticleSystem bloodParticle;
   
    void Start(){  
       int enemyTypes = transform.childCount;
       var chosenEnemy = transform.GetChild(Random.Range(1, enemyTypes));
       chosenEnemy.gameObject.SetActive(true);
    }
}
