using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Boss _boss;
    [SerializeField] private float _speed;

    private float _currentSpeed;
    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _currentSpeed = _speed;
        _image = GetComponent<RawImage>();
    }

    private void OnEnable()
    {
        _playerMover.SpeedChanged += OnSpeedChanged;
        _boss.Died += OnBossDied;
    }

    private void OnDisable()
    {
        _playerMover.SpeedChanged -= OnSpeedChanged;
        _boss.Died -= OnBossDied;
    }

    private void Update()
    {
        _imagePositionX += _currentSpeed * Time.deltaTime;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }

    private void OnSpeedChanged(float oldSpeed, float newSpeed)
    {
        _currentSpeed = _currentSpeed * (newSpeed / oldSpeed);
    }

    private void OnBossDied()
    {
        _currentSpeed = 0;
    }
}
