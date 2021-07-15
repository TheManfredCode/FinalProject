using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : Weapon
{
    private void OnEnable()
    {
        if(IsReloaded == false)
            StartCoroutine(Reload());
    }

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
