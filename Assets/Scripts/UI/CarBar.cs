using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarBar : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Slider _fuelbar;

    private void OnEnable()
    {
        _car.HealthChanged += OnHealthChanged;
        _car.FuelChanged += OnFuelChanged;
    }

    private void OnDisable()
    {
        _car.HealthChanged -= OnHealthChanged;
        _car.FuelChanged -= OnFuelChanged;
    }

    private void OnHealthChanged(int currentHealth, int MaxHealth)
    {
        _healthbar.value = (float)currentHealth / MaxHealth;
    }

    private void OnFuelChanged(float currentFuel, float maxFuel)
    {
        _fuelbar.value = currentFuel / maxFuel;
    }
}
