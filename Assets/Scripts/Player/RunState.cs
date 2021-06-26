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
    }

    private void OnEnable()
    {
        PlayerInput.ChangeShooter(_playerShooter);
    }
}
