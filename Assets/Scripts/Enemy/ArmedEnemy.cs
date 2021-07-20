using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArmedEnemy : Enemy
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _shotCount;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _dischargeRate;
    [SerializeField] private float _firstDischargeTime;
    [SerializeField] private UnityEvent _shooted;

    private float _elapsedTime;
    private WaitForSeconds _reloadTime;

    private new void OnEnable()
    {
        ResetHealth();
        _elapsedTime = _dischargeRate / _firstDischargeTime;
    }

    private void Start()
    {
        _reloadTime = new WaitForSeconds(_fireRate);
    }

    private void Update()
    {
        if(_elapsedTime >= _dischargeRate)
        {
            StartCoroutine(Discharge());
            _elapsedTime = 0;
        }

        _elapsedTime += Time.deltaTime;
    }

    private IEnumerator Discharge()
    {
        for (int i = 0; i < _shotCount; i++)
        {
            SingleShot();
            yield return _reloadTime;
        }
    }

    private void SingleShot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        _shooted?.Invoke();
    }
}
