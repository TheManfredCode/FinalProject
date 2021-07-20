using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : Weapon
{
    private void Awake()
    {
        FireType = "AUTO";
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            SingleShot();

            yield return ReloadTime;
        }
    }
}
