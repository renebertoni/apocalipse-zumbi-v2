using Microsoft.VisualBasic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySettings))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    private Animator _animator;

    void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate ()
    {
        var playerPosition = PlayerStatus.Position;
        DoMove(playerPosition);
        LookToTarget(playerPosition);
    }

    void DoMove(Vector3 targetPosition){
        _navMesh.destination = targetPosition;
        _animator.SetFloat(Constants.Get.MOVE_SPEED, _navMesh.velocity.magnitude);
    }

    void LookToTarget(Vector3 targetPosition){
        transform.LookAt(targetPosition);
    }
}
