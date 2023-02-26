using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh))]
public class EnemyMovement : CharacterMovementBase
{
    [SerializeField]
    LayerMask _targetLayerMask;
    NavMeshAgent _navMesh;

    [SerializeField]
    float _detectionDistance;
    float _defaultDetectionDistance;
    [SerializeField]
    float _stopDistance;
    [SerializeField]
    float _easeRotation;
    float _walkAroundDistance = 10f;
    float _timeToFindPosition = 10f;
    float _findPositionTimer;
    bool _chasing = false;
    Vector3 _targetPosition;

    protected override void Awake()
    {
        base.Awake();
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.speed = Speed;
        _navMesh.stoppingDistance = _stopDistance;
        _targetPosition = PlayerMovement.Position;
        _defaultDetectionDistance = _detectionDistance;
        _findPositionTimer = _timeToFindPosition + Random.Range(-1f,1f);
    }

    void OnEnable()
    {
        Flashlight.TurnOnOff += ChangeDetectionDistance;    
    }

    void OnDisable()
    {
        Flashlight.TurnOnOff -= ChangeDetectionDistance;    
    }

    void FixedUpdate ()
    {
        ChooseTarget();
        DoMove(_targetPosition);
        LookAtTarget(_targetPosition, _easeRotation);
    }

    public override void DoMove(Vector2 targetPosition)
    {
        Animator.SetFloat(Constants.MOVE_SPEED, _navMesh.velocity.magnitude);
    }

    // TODO MELHORARRRR
    void ChooseTarget()
    {
        var closeTargets = Helper.CloseTargets(transform.position, _detectionDistance, _targetLayerMask);

        if(closeTargets.HasCloseTarget)
        {
            _chasing = true;
            _targetPosition = closeTargets.Targets[0].transform.position;
            _navMesh.destination = _targetPosition;

            print(closeTargets.Targets[0].name);
        }
        else
        {
            if(_chasing) _navMesh.destination = transform.position;
            _chasing = false;

            _findPositionTimer -= Time.deltaTime;

            if(_findPositionTimer <= 0f)
            {
                _targetPosition = Helper.RandomPosition(transform, _walkAroundDistance);
                _navMesh.destination = _targetPosition;
                _findPositionTimer = _timeToFindPosition + Random.Range(-1f,1f);
            }
        }
    }

    void ChangeDetectionDistance(bool defaultSize)
    {
        _detectionDistance = defaultSize ? _defaultDetectionDistance : _detectionDistance * 0.8f;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _detectionDistance);
    }
}
