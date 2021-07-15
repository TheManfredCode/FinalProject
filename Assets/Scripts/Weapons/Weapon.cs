using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;

    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float FireRate;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Animator ShootAnimator;
    [SerializeField] protected string ShootAnimationName;

    [SerializeField] private UnityEvent _shooted;

    protected WaitForSeconds ReloadTime;
    protected bool IsReloaded = true;

    public string Label => _label;
    public int Price => _price;

    public event UnityAction Shooted;

    private void Start()
    {
        ReloadTime = new WaitForSeconds(FireRate);
    }

    abstract public IEnumerator Shoot();

    protected void SingleShot()
    {
        Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        Shooted?.Invoke();
        _shooted.Invoke();
    }

    protected IEnumerator Reload()
    {
        IsReloaded = false;
        yield return ReloadTime;
        IsReloaded = true;
    }
}