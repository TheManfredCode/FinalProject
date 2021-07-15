using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    [SerializeField] private Player _target;

    private void Start()
    {
        InitializeEnemies();
    }

    private void InitializeEnemies()
    {
        foreach (var poolObject in Pool)
        {
            if (poolObject.TryGetComponent(out Enemy enemy))
                enemy.SetTarget(_target);
        }
    }
}
