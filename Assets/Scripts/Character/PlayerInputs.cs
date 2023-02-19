using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerSettings))]
public class PlayerInputs : MonoBehaviour
{
    public static Action Shoot;
    public static Action DontShot;
    public static Action<Vector2> Move;
    public static Action<Vector2> Rotate;

    PlayerSettings playerSettings;

    void Awake()
    {
        playerSettings = GetComponent<PlayerSettings>();
    }

    void OnEnable()
    {
        playerSettings.shoot.action.performed += LeftMouseClick;
    }
    void OnDisable()
    {
        playerSettings.shoot.action.performed -= LeftMouseClick;
    }

    void FixedUpdate()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
        var inputDirection = playerSettings.movement.action.ReadValue<Vector2>();
        var inputRotation = playerSettings.pointerPosition.action.ReadValue<Vector2>();
        
        Rotate?.Invoke(inputRotation);
        Move?.Invoke(inputDirection.normalized);
    }

    void LeftMouseClick(InputAction.CallbackContext obj)
    {
        if(playerSettings.isAlive)
            Shoot?.Invoke();
        else
            DontShot?.Invoke();
    }
}
