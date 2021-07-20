using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private SellWeaponView _weaponViewTemplate;
    [SerializeField] private GameObject _weaponContainer;

    private Shooter _playerShooter;

    private void Start()
    {
        _playerShooter = _player.gameObject.GetComponent<Shooter>();
        Initialize();
    }

    public void Restart()
    {
        SellWeaponView[] sellWeaponViews = _weaponContainer.GetComponentsInChildren<SellWeaponView>();

        foreach (SellWeaponView sellWeaponView in sellWeaponViews)
        {
            sellWeaponView.Restart();
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            var view = Instantiate(_weaponViewTemplate, _weaponContainer.transform);
            view.Initialize(_weapons[i]);
            view.BuyButtonClicked += OnBuyButtonClicked;
            view.EquipButtonClicked += OnEquipButtonClicked;
        }
    }

    private void OnBuyButtonClicked(Weapon weapon, SellWeaponView weaponView)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.TryBuyWeapon(weapon);
            weaponView.Buying();
            weaponView.BuyButtonClicked -= OnBuyButtonClicked;
        }
    }

    private void OnEquipButtonClicked(Weapon weapon, SellWeaponView weaponView)
    {
        _playerShooter.ChangeWeapon(weapon);
        weaponView.EquipButtonClicked -= OnEquipButtonClicked;
    }
}
