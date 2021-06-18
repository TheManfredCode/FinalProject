using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : Weapon
{
    public override IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            yield return ReloadTime;
        }
    }
}
