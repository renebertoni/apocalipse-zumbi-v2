using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemySettings))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMesh;

    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate ()
    {
        var playerPosition = PlayerSettings.position;
        DoMove(playerPosition);
        LookToTarget(playerPosition);
    }

    void DoMove(Vector3 targetPosition){
        navMesh.destination = targetPosition;
    }

    void LookToTarget(Vector3 targetPosition){
        transform.LookAt(targetPosition);
    }
}
