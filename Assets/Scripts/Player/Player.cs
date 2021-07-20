using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _topScore;
    [SerializeField] private UnityEvent _died;
    [SerializeField] private UnityEvent _topScoreCollected;

    private int _currentHealth;
    private int _money = 0;
    private int _score = 0;

    public int Money => _money;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> ScoreChanged;

    public event UnityAction TopScoreCollected
    {
        add => _topScoreCollected.AddListener(value);
        remove => _topScoreCollected.RemoveListener(value);
    }
    public event UnityAction Died
    {
        add => _died.AddListener(value);
        remove => _died.RemoveListener(value);
    } 

    private void Start()
    {
        _currentHealth = _health;

        HealthChanged?.Invoke(_currentHealth, _health);
        MoneyChanged?.Invoke(_money);
        ScoreChanged?.Invoke(_score);
    }

    public void TryBuyWeapon(Weapon weapon)
    {
        if(weapon.Price <= _money)
        {
            _money -= weapon.Price;
            MoneyChanged?.Invoke(_money);
        }
    }

    public void TakeReward(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(_money);
    }

    public void TakeScore(int value)
    {
        _score += value;
        ScoreChanged?.Invoke(_score);

        if (_score >= _topScore)
            _topScoreCollected?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        _died?.Invoke();
    }

    public void Restart()
    {
        _currentHealth = _health;
        _score = 0;
        _money = 0;

        HealthChanged?.Invoke(_currentHealth, _health);
        ScoreChanged?.Invoke(_score);
        MoneyChanged?.Invoke(_money);

        transform.position = Vector3.zero;
    }
}
