using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellWeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _equipButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, SellWeaponView> BuyButtonClicked;
    public event UnityAction<Weapon, SellWeaponView> EquipButtonClicked;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
        _equipButton.onClick.AddListener(OnEquipButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
        _equipButton.onClick.RemoveListener(OnEquipButtonClick);
    }

    public void Initialize(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
    }

    public void Buying()
    {
        _buyButton.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(true);
    }

    public void Equipping()
    {
        _equipButton.gameObject.SetActive(false);
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClicked?.Invoke(_weapon, this);
    }

    private void OnEquipButtonClick()
    {
        EquipButtonClicked?.Invoke(_weapon, this);
    }
}
