using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float FireRate;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Animator ShootAnimator;
    [SerializeField] protected string ShootAnimationName;

    protected WaitForSeconds ReloadTime;
    protected bool IsReloaded = true;

    private void Start()
    {
        ReloadTime = new WaitForSeconds(FireRate);
    }

    abstract public IEnumerator Shoot();

    protected IEnumerator Reload()
    {
        IsReloaded = false;
        yield return ReloadTime;
        IsReloaded = true;
    }
}
