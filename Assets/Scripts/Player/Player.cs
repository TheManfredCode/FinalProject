using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject[] _weapons;

    private int _money = 0;
    private int _currentWeaponId;
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;

    private void Start()
    {
        InitializeWeapons();
    }

    public void ChangeWeapon()
    {

    }

    public void SwitchWeapon()
    {
        _weapons[_currentWeaponId].SetActive(false);

        if (_currentWeaponId == _weapons.Length - 1)
            _currentWeaponId = 0;
        else
            _currentWeaponId++;

        _weapons[_currentWeaponId].SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId].GetComponent<Weapon>();
    }

    public void TakeReward(int value)
    {
        _money += value;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void InitializeWeapons()
    {
        _currentWeaponId = 0;

        foreach (var weapon in _weapons)
        {
            weapon.SetActive(false);
        }

        _weapons[_currentWeaponId].SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId].GetComponent<Weapon>();
    }

    private void Die()
    {
        Debug.Log("pd");
    }
}
