using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _canisterSpread;
    [SerializeField] private int _canisterCount;

    public override IEnumerator Shoot()
    {
        if (IsReloaded)
        {
            for (int i = 0; i < _canisterCount; i++)
            {
                Vector3 canisterShootPosition = ShootPoint.position;
                canisterShootPosition += new Vector3(0, Random.Range(-_canisterSpread, +_canisterSpread), 0);

                Instantiate(Bullet, canisterShootPosition, Quaternion.identity);
            }
            StartCoroutine(Reload());
        }
        yield return null;
    }
}
