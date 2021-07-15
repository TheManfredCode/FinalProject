using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateSwitcher))]
[RequireComponent(typeof(RunState))]
[RequireComponent(typeof(SpriteRenderer))]
public class DriveState : State
{
    [SerializeField] private Car _car;
    [SerializeField] private GameObject _carObject;
    [SerializeField] private Shooter _carShooter;
    [SerializeField] private SpriteRenderer _playerSprite;

    private Color _playerStartColor;
    private StateSwitcher _stateSwitcher;
    private RunState _runState;

    private void Start()
    {
        _stateSwitcher = GetComponent<StateSwitcher>();
        _runState = GetComponent<RunState>();
    }

    private void OnEnable()
    {
        _playerStartColor = _playerSprite.color;
        _playerSprite.color = new Color(1, 1, 1, 0);

        _carObject.SetActive(true);
        PlayerInput.SetShooter(_carShooter);

        _car.Stopped += OnFuelExpired;
    }

    private void OnDisable()
    {
        _playerSprite.color = _playerStartColor;
        _carObject.SetActive(false);

        _car.Stopped -= OnFuelExpired;
    }

    private void OnFuelExpired()
    {
        _stateSwitcher.SwitchState(_runState);
    }
}
