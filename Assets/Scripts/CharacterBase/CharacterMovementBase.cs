using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBase : MonoBehaviour, IMovement
{
    [SerializeField]
    protected float _speed;
    protected Animator _animator;
    protected CharacterController _characterController;

    protected virtual void Awake(){
        this._animator = GetComponent<Animator>();
        this._characterController = GetComponent<CharacterController>();
    }

    public virtual void DoMove(Vector2 position){}

    public virtual void LookAtTarget(Vector2 position){}
}
