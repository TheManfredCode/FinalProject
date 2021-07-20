using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Car : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _fuel;
    [SerializeField] private float _fuelExpenditure;
    [SerializeField] private float _carSpeed;

    private int _currentHealth;
    private float _currentFuel;

    public event UnityAction<float> Launched;
    public event UnityAction Stopped;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<float, float> FuelChanged;

    private void OnEnable()
    {
        ResetStats();
        Launched?.Invoke(_carSpeed);
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    private void OnDisable()
    {
        Stopped?.Invoke();
    }

    private void Update()
    {
        _currentFuel -= Time.deltaTime * _fuelExpenditure;
        FuelChanged(_currentFuel, _fuel);

        if(_currentFuel <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }

    public void ResetStats()
    {
        _currentHealth = _health;
        _currentFuel = _fuel;

        HealthChanged?.Invoke(_currentHealth, _health);
        FuelChanged?.Invoke(_currentFuel, _fuel);
    }
}
