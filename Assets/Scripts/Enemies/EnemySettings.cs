using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public ParticleSystem bloodParticle;

    NavMeshAgent navMesh;

    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.velocity = new Vector3(0.1f,0.1f,0.1f);
    }
    
    void Start()
    {  
       int enemyTypes = transform.childCount;
       var chosenEnemy = transform.GetChild(Random.Range(1, enemyTypes));
       chosenEnemy.gameObject.SetActive(true);

        if(navMesh)
        {
            navMesh.speed = this.speed;
            navMesh.stoppingDistance = this.stopDistance;
        }
    }
}
