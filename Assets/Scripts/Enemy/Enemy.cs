using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _reward;

    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Die();
        }
        if(collision.TryGetComponent(out Edge edge))
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
        if(_reward != null)
            Instantiate(_reward, transform.position, Quaternion.identity);
    }
}
