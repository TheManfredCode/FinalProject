using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerFighter))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private string _shootAnimationName;
    [SerializeField] private string _hitAnimationName;

    private Animator _animator;
    private Shooter _shooter;
    private Weapon _currentWeapon;
    private PlayerInput _playerInput;
    private PlayerFighter _playerFighter;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.ShooterChanged += OnShooterChanged;

        _playerFighter = GetComponent<PlayerFighter>();
        _playerFighter.Hit += OnHit;

        _shooter = GetComponent<Shooter>();
        _shooter.WeaponSwitched += OnWeaponSwitched;

        _currentWeapon = _shooter.CurrentWeapon;
        _currentWeapon.Shooted += OnShooted;
        _animator = _currentWeapon.gameObject.GetComponent<Animator>();
    }

    private void OnShooted()
    {
        //shoot anim
        Debug.Log("SHOT_ANIM");
    }

    private void OnHit()
    {
        //hit anim
        Debug.Log("HIT_ANIM");
    }

    private void OnWeaponSwitched()
    {
        _currentWeapon.Shooted -= OnShooted;
        _currentWeapon = _shooter.CurrentWeapon;

        _animator = _currentWeapon.gameObject.GetComponent<Animator>();
        _currentWeapon.Shooted += OnShooted;
    }

    private void OnShooterChanged(Shooter shooter)
    {
        _shooter = shooter;
        OnWeaponSwitched();
    }
}
