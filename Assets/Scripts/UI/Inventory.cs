using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _switchWeaponButton;
    [SerializeField] private InventoryWeaponView _weaponView;

    private Shooter _playerShooter;

    private void OnEnable()
    {
        if(_playerShooter != null)
            _playerShooter.WeaponSwitched += OnWeaponSwitched;
        _switchWeaponButton.onClick.AddListener(OnSwitchWeaponButtonPressed);
    }

    private void OnDisable()
    {
        if (_playerShooter != null)
            _playerShooter.WeaponSwitched -= OnWeaponSwitched;
        _switchWeaponButton.onClick.RemoveListener(OnSwitchWeaponButtonPressed);
    }

    private void Start()
    {
        _playerShooter = _player.gameObject.GetComponent<Shooter>();
        _playerShooter.WeaponSwitched += OnWeaponSwitched;

        _weaponView.Render(_playerShooter.CurrentWeapon);
    }

    private void OnSwitchWeaponButtonPressed()
    {
        _playerShooter.SwitchWeapon();
    }

    private void OnWeaponSwitched()
    {
        _weaponView.Render(_playerShooter.CurrentWeapon);
    }
}
