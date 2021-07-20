using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateSwitcher))]
[RequireComponent(typeof(RunState))]
[RequireComponent(typeof(SpriteRenderer))]
public class DriveState : State
{
    [SerializeField] private Car _car;
    [SerializeField] private Shooter _carShooter;
    [SerializeField] private GameObject _carInterface;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _driveStateClip;

    private SpriteRenderer _playerSprite;
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
        _playerSprite = GetComponent<SpriteRenderer>();

        _playerStartColor = _playerSprite.color;
        _playerSprite.color = new Color(1, 1, 1, 0);

        _car.gameObject.SetActive(true);
        _carInterface.SetActive(true);
        PlayerInput.SetShooter(_carShooter);

        _audioSource.PlayOneShot(_driveStateClip);

        _car.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _audioSource.Stop();

        _playerSprite.color = _playerStartColor;
        _car.gameObject.SetActive(false);
        _carInterface.SetActive(false);

        _car.Stopped -= OnStopped;
    }

    private void OnStopped()
    {
        _stateSwitcher.SwitchState(_runState);
    }
}
