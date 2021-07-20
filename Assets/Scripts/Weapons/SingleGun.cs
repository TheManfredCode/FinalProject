using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : Weapon
{
    public override IEnumerator Shoot()
    {
        if (IsReloaded)
        {
            SingleShot();
            StartCoroutine(Reload());
        }
        yield return null;
    }
}
