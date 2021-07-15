using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon[] _startWeapons;
    [SerializeField] private Transform _weaponContainer;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _currentWeaponId;
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction WeaponSwitched;

    private void Awake()
    {
        InitializeWeapons();
    }

    public void SwitchWeapon()
    {
        _weapons[_currentWeaponId].gameObject.SetActive(false);

        if (_currentWeaponId == _weapons.Count - 1)
            _currentWeaponId = 0;
        else
            _currentWeaponId++;

        _weapons[_currentWeaponId].gameObject.SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId].GetComponent<Weapon>();

        WeaponSwitched?.Invoke();
    }

    public void ChangeWeapon(Weapon weapon)
    {
        Destroy(_currentWeapon.gameObject);

        _weapons[_currentWeaponId] = Instantiate(weapon, _weaponContainer);

        _weapons[_currentWeaponId].gameObject.SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId];

        WeaponSwitched?.Invoke();
    }

    private void InitializeWeapons()
    {
        _currentWeaponId = 0;

        foreach (Weapon weapon in _startWeapons)
        {
            Weapon instantiatedWeapon = Instantiate(weapon, _weaponContainer);
            _weapons.Add(instantiatedWeapon);
            instantiatedWeapon.gameObject.SetActive(false);
        }

        _weapons[_currentWeaponId].gameObject.SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId];
    }
}
