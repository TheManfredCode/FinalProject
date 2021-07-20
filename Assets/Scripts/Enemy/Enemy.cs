using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _reward;
    [SerializeField] private int _scoreForDeath;

    private int _currentHealth;
    private Player _target;

    public Player Target => _target;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            player.TakeScore(_scoreForDeath);
            Die();
        }
        if(collision.TryGetComponent(out Car car))
        {
            car.TakeDamage(_damage);
            _target.TakeScore(_scoreForDeath);
            Die();
        }
        if(collision.TryGetComponent(out Edge edge))
        {
            Die();
        }
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _target.TakeScore(_scoreForDeath);
            Die();
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);

        if(_reward != null)
            Instantiate(_reward, transform.position, Quaternion.identity);
    }
}
