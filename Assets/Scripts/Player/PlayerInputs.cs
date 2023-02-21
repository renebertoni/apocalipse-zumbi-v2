using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerInputs : MonoBehaviour
{
    public static Action OnShoot;
    public static Action DontShoot;
    public static Action<Vector2> Move;
    public static Action<Vector2> Rotate;

    public InputActionReference Movement, Shoot, PointerPosition;
    PlayerHealth _playerHealth;

    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void OnEnable()
    {
        Shoot.action.performed += LeftMouseClick;
    }

    void OnDisable()
    {
        Shoot.action.performed -= LeftMouseClick;
    }

    void FixedUpdate()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
        var inputDirection = Movement.action.ReadValue<Vector2>();
        var inputRotation = PointerPosition.action.ReadValue<Vector2>();
        
        Rotate?.Invoke(inputRotation);
        Move?.Invoke(inputDirection.normalized);
    }

    void LeftMouseClick(InputAction.CallbackContext obj)
    {
        if(_playerHealth.IsAlive) OnShoot?.Invoke();
        else DontShoot?.Invoke();// TODO REMOVER ISSO E REINICIAR POR BOTAO
    }
}
