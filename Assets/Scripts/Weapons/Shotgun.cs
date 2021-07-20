using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _canisterSpread;
    [SerializeField] private int _canisterCount;

    private Vector3 _startShootPosition;

    public override IEnumerator Shoot()
    {
        if (IsReloaded)
        {
            for (int i = 0; i < _canisterCount; i++)
            {
                _startShootPosition = ShootPoint.position;

                Vector3 canisterShootPosition = ShootPoint.position;
                canisterShootPosition += new Vector3(0, Random.Range(-_canisterSpread, +_canisterSpread), 0);
                ShootPoint.position = canisterShootPosition;

                Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
                ShootPoint.position = _startShootPosition;
            }
            Shooted?.Invoke();
            StartCoroutine(Reload());
        }
        yield return null;
    }
}
