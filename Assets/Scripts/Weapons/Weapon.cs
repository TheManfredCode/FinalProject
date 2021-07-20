using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private UnityEvent _shooted;

    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float FireRate;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Animator ShootAnimator;
    [SerializeField] protected string ShootAnimationName;

    protected UnityEvent Shooted => _shooted;

    protected WaitForSeconds ReloadTime;
    protected bool IsReloaded = true;

    public string Label => _label;
    public int Price => _price;

    private void OnEnable()
    {
        if (IsReloaded == false)
            StartCoroutine(Reload());
    }

    private void Start()
    {
        ReloadTime = new WaitForSeconds(FireRate);
    }

    abstract public IEnumerator Shoot();

    protected void SingleShot()
    {
        Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        _shooted.Invoke();
    }

    protected IEnumerator Reload()
    {
        IsReloaded = false;
        yield return ReloadTime;
        IsReloaded = true;
    }
}