using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyView : ValuePanel
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.MoneyChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnValueChanged;
    }
}
