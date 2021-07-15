using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _topScore;

    private SpriteRenderer _sprite;
    private int _currentHealth;
    private int _money = 10;
    private int _score = 0;

    public int Money => _money;

    public event UnityAction TopScoreCollected;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _currentHealth = _health;
    }

    public void TryBuyWeapon(Weapon weapon)
    {
        if(weapon.Price <= _money)
        {
            _money -= weapon.Price;
            Debug.Log(weapon.Label + " BUYED");
        }
        else
        {
            Debug.Log("NOT ENOUGH");
        }
    }

    public void TakeReward(int value)
    {
        _money += value;
    }

    public void TakeScore(int value)
    {
        _score += value;
        if (_score >= _topScore)
            TopScoreCollected?.Invoke();
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
