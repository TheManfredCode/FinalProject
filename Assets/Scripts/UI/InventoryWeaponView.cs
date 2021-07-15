using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryWeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;

    public void Render(Weapon weapon)
    {
        _label.text = weapon.Label;
    }
}
