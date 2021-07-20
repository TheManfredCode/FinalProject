using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _image;

    public void Render(Weapon weapon)
    {
        _label.text = weapon.Label;
        _description.text = weapon.GetDescription();
        _image.sprite = weapon.Image;
    }
}
