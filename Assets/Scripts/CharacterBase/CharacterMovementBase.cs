using UnityEngine;

public class CharacterMovementBase : MonoBehaviour, IMovement
{
    [SerializeField]
    protected float Speed;
    protected Animator Animator;
    protected CharacterController CharacterController;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
    }

    public virtual void DoMove(Vector2 position){}

    public virtual void LookAtTarget(Vector2 position){}
}
