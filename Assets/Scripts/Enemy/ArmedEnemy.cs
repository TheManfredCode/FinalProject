using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : Enemy
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _shotCount;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _dischargeRate;

    private float _elapsedTime = 0;
    private WaitForSeconds _reloadTime;

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
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            yield return _reloadTime;
        }
    }
}
