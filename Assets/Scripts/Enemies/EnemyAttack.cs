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
    Helper _helper;
    CloseTarget _closeTargets;

    public static Action<int> Hit;
    public static Action<string> PlayAudio;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _helper = new Helper();
    }

    void FixedUpdate()
    {
        _closeTargets = _helper.CloseTargets(transform.position + transform.forward, _attackDistance, _targetLayerMask);
        _canHit = _closeTargets.HasCloseTarget;
        _animator.SetBool(Constants.ATTACK, _canHit);
    }

    public void Attack()
    {
        PlayAudio?.Invoke(Constants.ZOMBIE_ATTACK);

        StartCoroutine(IsAttacking(true, 0f));
        StartCoroutine(IsAttacking(false, 1f));
    }

    // bool NearTheTarget()
    // {
    //     Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, _attackDistance, _targetLayerMask);
    //     return hitColliders.Length > 0;
    // }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.forward, 1f);
    }

    public void DoHit()
    {
        if(_canHit) _closeTargets.Targets[0].GetComponent<CharacterHealthBase>().ReceiveDamage(20);
        // if(_canHit) Hit?.Invoke(20);
    }

    IEnumerator IsAttacking(bool status, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        if(_navMeshAgent.isActiveAndEnabled) _navMeshAgent.isStopped = status;
    }
}
