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
            ShootAnimator.Play(ShootAnimationName);
            Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            StartCoroutine(Reload());
        }

        yield return null;
    }
}
