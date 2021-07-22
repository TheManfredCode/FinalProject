using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _price;

    [SerializeField] protected PlayerBullet Bullet;
    [SerializeField] protected float FireRate;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Animator ShootAnimator;
    [SerializeField] protected string ShootAnimationName;

    protected string FireType;
    protected UnityEvent Shooted => _shooted;
    protected WaitForSeconds ReloadTime;
    protected bool IsReloaded = true;

    [SerializeField] private UnityEvent _shooted;

    public string Label => _label;
    public Sprite Image => _image;
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

    public string GetDescription()
    {
        string description = $"Описание :\n\nУрон : {Bullet.Damage}\nСкорость пули : {Bullet.Speed}\nрежим огня : {FireType}\nСкорострельность :{FireRate}";
        return description;
    }

    protected void SingleShot()
    {
        Instantiate(Bullet.gameObject, ShootPoint.position, Quaternion.identity);
        _shooted.Invoke();
    }

    protected IEnumerator Reload()
    {
        IsReloaded = false;
        yield return ReloadTime;
        IsReloaded = true;
    }
}