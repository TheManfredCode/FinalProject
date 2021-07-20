using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Shooter))]
public class PlayerFighter : MonoBehaviour
{
    [SerializeField] private string _animationName;

    private Shooter _shooter;
    private Weapon _currentWeapon;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
        _currentWeapon = _shooter.CurrentWeapon;
        _shooter.WeaponSwitched += OnWeaponSwitched;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            if (_currentWeapon.gameObject.TryGetComponent(out Animator animator))
                animator.Play(_animationName);
        }
    }

    private void OnWeaponSwitched()
    {
        _currentWeapon = _shooter.CurrentWeapon;
    }
}
