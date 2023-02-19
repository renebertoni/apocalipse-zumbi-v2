using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Start() {
        _slider = GetComponent<Slider>();
        _slider.value = 1;
    }

    private void OnEnable() {
        PlayerHealth.OnDamage += UpdateHealthBar;
    }

    private void OnDisable() {
        PlayerHealth.OnDamage -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int health){
        _slider.value = health / 100f;
    }
}
