using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    #region Components
        public InputActionReference Movement, Shoot, PointerPosition;
        [HideInInspector]
        public CharacterController CharacterController;
        [HideInInspector]
        public Animator Animator;
    #endregion

    #region Attibutes
        public float Speed = 2;
        [HideInInspector]
        public static Vector3 Position;
        [HideInInspector]
    #endregion

    private void Awake(){
        CharacterController = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        Position = transform.position;
    }
}

