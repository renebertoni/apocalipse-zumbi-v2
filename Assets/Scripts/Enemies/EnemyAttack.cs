using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioAttack;
    [SerializeField]
    LayerMask _layerMask;
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    bool _canHit;

    public static Action<int> Hit;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        NearTheTarget();
        _animator.SetBool(Constants.Get.ATTACK, _canHit);
    }

    public void Attack()
    {
        _audioAttack.Play();

        StartCoroutine(IsAttacking(true, 0f));
        StartCoroutine(IsAttacking(false, 1f));
    }

    void NearTheTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, 1f, _layerMask);
        _canHit = hitColliders.Length > 0;
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
