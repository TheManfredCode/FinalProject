using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateSwitcher))]
[RequireComponent(typeof(RunState))]
public class DriveState : State
{
    [SerializeField] private Car _car;
    [SerializeField] private GameObject _carObject;
    [SerializeField] private Shooter _carShooter;

    private StateSwitcher _stateSwitcher;
    private RunState _runState;

    private void Start()
    {
        _stateSwitcher = GetComponent<StateSwitcher>();
        _runState = GetComponent<RunState>();
    }

    private void OnEnable()
    {
        PlayerInput.ChangeShooter(_carShooter);
        _carObject.SetActive(true);

        _car.ResetStats();
        _car.FuelExpired += OnFuelExpired;
    }

    private void OnDisable()
    {
        _carObject.SetActive(false);

        _car.FuelExpired -= OnFuelExpired;
    }

    private void OnFuelExpired()
    {
        _stateSwitcher.SwitchState(_runState);
    }
}
