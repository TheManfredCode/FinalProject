using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Car : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _fuel;
    [SerializeField] private float _fuelExpenditure;

    private int _currentHealth;
    private float _currentFuel;

    public event UnityAction FuelExpired;
    public event UnityAction CarDestroyed;

    private void Start()
    {
        ResetStats();
    }

    private void Update()
    {
        _currentFuel -= Time.deltaTime * _fuelExpenditure;

        if(_currentFuel <= 0)
        {
            FuelExpired?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            CarDestroyed.Invoke();
    }

    public void ResetStats()
    {
        _currentHealth = _health;
        _currentFuel = _fuel;
    }
}
