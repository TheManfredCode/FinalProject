using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : ValuePanel
{
    [SerializeField] Player _player;

    private void Awake()
    {
        _player.ScoreChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnValueChanged;
    }
}
