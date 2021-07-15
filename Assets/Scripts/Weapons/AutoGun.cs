using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : Weapon
{

    public override IEnumerator Shoot()
    {
        while (true)
        {
            SingleShot();

            yield return ReloadTime;
        }
    }
}
