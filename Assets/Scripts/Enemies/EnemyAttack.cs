using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioAttack;
    [SerializeField]
    LayerMask _targetLayerMask;
    NavMeshAgent _navMeshAgent;
    Animator _animator;

    [SerializeField]
    float _attackDistance;
    bool _canHit;

    public static Action<int> Hit;
    public static Action<string> PlayAudio;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _canHit = NearTheTarget();
        _animator.SetBool(Constants.ATTACK, _canHit);
    }

    public void Attack()
    {
        PlayAudio?.Invoke(Constants.ZOMBIE_ATTACK);

        StartCoroutine(IsAttacking(true, 0f));
        StartCoroutine(IsAttacking(false, 1f));
    }

    bool NearTheTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, _attackDistance, _targetLayerMask);
        return hitColliders.Length > 0;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.forward, 1f);
    }

    public void DoHit()
    {
        if(_canHit) Hit?.Invoke(20);
    }

    IEnumerator IsAttacking(bool status, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _navMeshAgent.isStopped = status;
    }
}
