using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;
    private Player _player;

    private void Start()
    {
        _currentState = _startState;
        _currentState.Enter();
    }

    public void SwitchState(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
