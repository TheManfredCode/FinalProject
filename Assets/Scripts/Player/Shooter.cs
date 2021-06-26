using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject[] _startWeapons;
    [SerializeField] private Transform _weaponContainer;

    private List<GameObject> _weapons = new List<GameObject>();
    private int _currentWeaponId;
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;

    private void Start()
    {
        InitializeWeapons();
    }

    public void SwitchWeapon()
    {
        _weapons[_currentWeaponId].SetActive(false);

        if (_currentWeaponId == _weapons.Count - 1)
            _currentWeaponId = 0;
        else
            _currentWeaponId++;

        _weapons[_currentWeaponId].SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId].GetComponent<Weapon>();
    }

    private void InitializeWeapons()
    {
        _currentWeaponId = 0;

        foreach (var weapon in _startWeapons)
        {
            GameObject instantiatedWeapon = Instantiate(weapon, _weaponContainer);
            _weapons.Add(instantiatedWeapon);
            instantiatedWeapon.SetActive(false);
        }

        _weapons[_currentWeaponId].SetActive(true);
        _currentWeapon = _weapons[_currentWeaponId].GetComponent<Weapon>();
    }
}
