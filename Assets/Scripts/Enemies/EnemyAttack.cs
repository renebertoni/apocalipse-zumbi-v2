using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    AudioSource audioAttack;
    NavMeshAgent navMeshAgent;
    Animator animator;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        var isAttacking = navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
        animator.SetBool(Constants.Get.ATTACK, isAttacking);
    }

    public void PlaySound()
    {
        audioAttack.Play();
    }
}
