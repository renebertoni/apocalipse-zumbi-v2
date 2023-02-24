using UnityEngine;

public class CharacterMovementBase : MonoBehaviour, IMovement
{
    [SerializeField]
    protected float Speed;
    protected Animator Animator;
    protected CharacterController CharacterController;
    protected Helper Helper;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        Helper = new Helper();
    }

    public virtual void DoMove(Vector2 position){}

    public void LookAtTarget(Vector3 targetPosition, float ease)
    {
        var targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, ease * Time.deltaTime);
    }
}
