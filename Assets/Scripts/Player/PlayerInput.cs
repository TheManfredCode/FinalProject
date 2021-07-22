using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private PlayerMover _mover;
    private Shooter _shooter;
    private Coroutine _shootCorutine;

    private void Start()
    {
        _player = GetComponent<Player>();
        _mover = GetComponent<PlayerMover>();

        ChangeShooter(GetComponent<Shooter>());
    }

    private void OnEnable()
    {
        if (_shooter != null)
            _shooter.WeaponSwitched += OnWeaponSwitched;

        if (_shootCorutine != null)
            StopCoroutine(_shootCorutine);
    }

    private void OnDisable()
    {
        if (_shooter != null)
            _shooter.WeaponSwitched -= OnWeaponSwitched;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _mover.IsGrounded)
            _mover.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S) && _mover.IsGrounded)
            _mover.TryMoveDown();

        if (Input.GetKeyDown(KeyCode.Space) && _mover.IsGrounded)
            StartCoroutine(_mover.Jump());

        if (Input.GetKeyDown(KeyCode.E))
            _shooter.SwitchWeapon();

        if (Input.GetMouseButtonDown(0))
            _shootCorutine = StartCoroutine(_shooter.CurrentWeapon.Shoot());

        if (Input.GetMouseButtonUp(0))
            StopCoroutine(_shootCorutine);
    }

    public void ChangeShooter(Shooter shooter)
    {
        if(_shooter != null)
            _shooter.WeaponSwitched -= OnWeaponSwitched;

        _shooter = shooter;
        _shooter.WeaponSwitched += OnWeaponSwitched;

        if (_shootCorutine != null)
            StopCoroutine(_shootCorutine);
    }

    private void OnWeaponSwitched()
    {
        if (_shootCorutine != null)
            StopCoroutine(_shootCorutine);
    }
}
