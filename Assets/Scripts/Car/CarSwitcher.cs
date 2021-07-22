using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInput))]
public class CarSwitcher : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Shooter _carShooter;
    [SerializeField] private GameObject _carInterface;

    private PlayerInput _playerInput;
    private Shooter _playerShooter;
    private SpriteRenderer _playerSprite;
    private BoxCollider2D _playerCollider;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerShooter = GetComponent<Shooter>();
        _playerCollider = GetComponent<BoxCollider2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _car.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _car.Stopped -= OnStopped;
    }

    public void LaunchCar()
    {
        _playerCollider.enabled = false;
        _playerSprite.enabled = false;

        _carInterface.SetActive(true);
        _car.gameObject.SetActive(true);

        _playerInput.ChangeShooter(_carShooter);
    }

    private void OnStopped()
    {
        _playerCollider.enabled = true;
        _playerSprite.enabled = true;

        _carInterface.SetActive(false);

        _playerInput.ChangeShooter(_playerShooter);
    }
}
