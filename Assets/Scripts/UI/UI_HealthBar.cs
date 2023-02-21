using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 1;
    }

    void OnEnable()
    {
        PlayerHealth.OnDamage += UpdateHealthBar;
    }

    void OnDisable()
    {
        PlayerHealth.OnDamage -= UpdateHealthBar;
    }

    void UpdateHealthBar(int health)
    {
        _slider.value = health / 100f;
    }
}
