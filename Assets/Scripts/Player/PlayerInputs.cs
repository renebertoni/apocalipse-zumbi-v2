using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerInputs : MonoBehaviour
{
    public static Action Shoot;
    public static Action DontShot;
    public static Action<Vector2> Move;
    public static Action<Vector2> Rotate;

    PlayerStatus playerStatus;
    PlayerHealth playerHealth;

    void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnEnable()
    {
        playerStatus.Shoot.action.performed += LeftMouseClick;
    }
    void OnDisable()
    {
        playerStatus.Shoot.action.performed -= LeftMouseClick;
    }

    void FixedUpdate()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
        var inputDirection = playerStatus.Movement.action.ReadValue<Vector2>();
        var inputRotation = playerStatus.PointerPosition.action.ReadValue<Vector2>();
        
        Rotate?.Invoke(inputRotation);
        Move?.Invoke(inputDirection.normalized);
    }

    void LeftMouseClick(InputAction.CallbackContext obj)
    {
        if(playerHealth.IsAlive)
            Shoot?.Invoke();
        else
            DontShot?.Invoke();// TODO REMOVER ISSO E REINICIAR POR BOTAO
    }
}
