using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ArmedEnemy))]
[RequireComponent(typeof(Animator))]
public class ArmedEnemyAnimator : MonoBehaviour
{
    [SerializeField] private string _shootAnimationName;

    private Animator _animator;
    private ArmedEnemy _enemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _enemy = GetComponent<ArmedEnemy>();
        _enemy.Shooted += OnShooted;
    }

    private void OnEnable()
    {
        if (_enemy != null)
            _enemy.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        if (_enemy != null)
            _enemy.Shooted -= OnShooted;
    }

    private void OnShooted()
    {
        Debug.Log("ENEMYSHH");
        //shoot anim
    }
}
