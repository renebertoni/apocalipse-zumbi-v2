using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh))]
public class EnemyMovement : CharacterMovementBase
{
    [SerializeField]
    float _stopDistance;
    NavMeshAgent _navMesh;

    protected override void Awake()
    {
        base.Awake();
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.speed = Speed;
    }

    void FixedUpdate ()
    {
        var playerPosition = PlayerMovement.Position;
        var position = new Vector2(playerPosition.x, playerPosition.z);
        DoMove(position);
        LookAtTarget(position);
    }

    public override void DoMove(Vector2 targetPosition)
    {
        var position = new Vector3(targetPosition.x, 0, targetPosition.y);
        _navMesh.destination = position;
        Animator.SetFloat(Constants.Get.MOVE_SPEED, _navMesh.velocity.magnitude);
    }

    public override void LookAtTarget(Vector2 targetPosition)
    {
        var position = new Vector3(targetPosition.x, 0, targetPosition.y);
        transform.LookAt(position);
    }
}
