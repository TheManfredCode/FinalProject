using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ObjectPool[] _objectPools;

    private void OnEnable()
    {
        _target.TopScoreCollected += OnTopScoreCollected;
    }

    private void OnDisable()
    {
        _target.TopScoreCollected -= OnTopScoreCollected;
    }

    private void OnTopScoreCollected()
    {
        _boss.gameObject.SetActive(true);
        _boss.transform.position = _spawnPoint.position;
        _boss.SetTarget(_target);

        foreach (var objectPool in _objectPools)
        {
            objectPool.gameObject.SetActive(false);
        }
    }
}
