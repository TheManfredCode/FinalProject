using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Start()
    {
        Direction = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
            Destroy(gameObject);
        }
        if(collision.TryGetComponent(out Car car))
        {
            car.TakeDamage(Damage);
            Destroy(gameObject);
        }
        if(collision.TryGetComponent(out Edge edge))
        {
            Destroy(gameObject);
        }
    }
}
