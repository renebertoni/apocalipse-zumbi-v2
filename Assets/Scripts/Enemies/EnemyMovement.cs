using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySettings))]
public class EnemyMovement : CharacterMovementBase
{
    [SerializeField]
    private float _stopDistance;
    private NavMeshAgent _navMesh;

    protected override void Awake(){
        base.Awake();
        this._navMesh = GetComponent<NavMeshAgent>();

        if(this._navMesh){
            this._navMesh.speed = this._speed;
            this._navMesh.stoppingDistance = this._stopDistance;
        }
    }

    void FixedUpdate (){
        var playerPosition = PlayerStatus.Position;
        var position = new Vector2(playerPosition.x, playerPosition.z);
        DoMove(position);
        LookAtTarget(position);
    }

    public override void DoMove(Vector2 targetPosition){
        var position = new Vector3(targetPosition.x, 0, targetPosition.y);
        this._navMesh.destination = position;
        this._animator.SetFloat(Constants.Get.MOVE_SPEED, _navMesh.velocity.magnitude);
    }

    public override void LookAtTarget(Vector2 targetPosition){
        var position = new Vector3(targetPosition.x, 0, targetPosition.y);
        transform.LookAt(position);
    }
}
