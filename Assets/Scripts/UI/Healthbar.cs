using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : Bar
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
