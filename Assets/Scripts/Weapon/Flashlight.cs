using UnityEngine;
using System;

public class Flashlight : MonoBehaviour
{
    public static Action<bool> TurnOnOff;

    Light[] _light;
    bool _lightOn = true;

    void Start()
    {
        _light = GetComponentsInChildren<Light>();
    }

    void OnEnable()
    {
        PlayerInputs.Flashlight += TurnOn;    
    }

    void OnDisable()
    {
        PlayerInputs.Flashlight -= TurnOn;    
    }

    void TurnOn()
    {
        foreach (var light in _light)
        {
            light.enabled = !light.enabled;
        }
        _lightOn = !_lightOn;

        TurnOnOff?.Invoke(_lightOn);
    }
}
