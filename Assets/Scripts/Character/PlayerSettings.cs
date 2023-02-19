using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSettings : MonoBehaviour
{
    // components
    public InputActionReference movement, shoot, pointerPosition;
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public Animator animator;
    public bool isAlive = true;

    // attributes
    public static Vector3 position;
    public float speed = 2;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GameHandler.GameOver += DoDie;
    }
    void OnDisable()
    {
        GameHandler.GameOver -= DoDie;
    }

    void FixedUpdate()
    {
        position = transform.position;
    }

    void DoDie()
    {
        isAlive = false;
    }
}

