using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerInputs : MonoBehaviour
{
    public static Action Shoot;
    public static Action Flashlight;
    public static Action<Vector2> Move;
    public static Action<Vector2> Rotate;

    public InputActionReference MovementInput, ShootInput, PointerPosition, FlashlightInput;
    PlayerHealth _playerHealth;

    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void OnEnable()
    {
        ShootInput.action.performed += DoShoot;
        FlashlightInput.action.performed += SwithFlashlight;
    }

    void OnDisable()
    {
        ShootInput.action.performed -= DoShoot;
        FlashlightInput.action.performed -= SwithFlashlight;

    }

    void FixedUpdate()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
        var inputDirection = MovementInput.action.ReadValue<Vector2>();
        var inputRotation = PointerPosition.action.ReadValue<Vector2>();
        
        Rotate?.Invoke(inputRotation);
        Move?.Invoke(inputDirection.normalized);
    }

    void DoShoot(InputAction.CallbackContext obj)
    {
        if(_playerHealth.IsAlive) Shoot?.Invoke();
    }

    void SwithFlashlight(InputAction.CallbackContext obj)
    {
        if(_playerHealth.IsAlive) Flashlight?.Invoke();
    }
}
