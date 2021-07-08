using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private SpriteRenderer _sprite;
    private int _currentHealth;
    private int _money = 0;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _currentHealth = _health;
    }
    
    public void TakeReward(int value)
    {
        _money += value;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("pd");
    }
}
