using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class RunState : State
{
    private Shooter _playerShooter;

    private void Start()
    {
        _playerShooter = GetComponent<Shooter>();
        PlayerInput.SetShooter(_playerShooter);
    }

    private void OnEnable()
    {
        if(_playerShooter != null)
            PlayerInput.SetShooter(_playerShooter);
    }
}
