using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Player _player;
    [SerializeField] private Car _car;
    [SerializeField] private Shop _shop;
    [SerializeField] private Boss _boss;
    [SerializeField] private ObjectPool[] _objectPools;

    [SerializeField] private UnityEvent _restarted;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        _player.Restart();
        _player.GetComponent<Shooter>().Restart();

        _car.gameObject.SetActive(false);

        _cameraMover.Restart();
        _shop.Restart();

        foreach (ObjectPool objectPool in _objectPools)
        {
            objectPool.gameObject.SetActive(true);
            objectPool.Restart();
        }

        _boss.gameObject.SetActive(false);

        _restarted?.Invoke();
    }
}
