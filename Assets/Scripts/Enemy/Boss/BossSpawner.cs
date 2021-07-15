using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ObjectPool[] _objectPools;
    [SerializeField] private BossLauncher _bossTemplate;
    [SerializeField] private Transform _spawnPoint;

    private void OnEnable()
    {
        _player.TopScoreCollected += OnTopScoreCollected;
    }

    private void OnDisable()
    {
        _player.TopScoreCollected -= OnTopScoreCollected;
    }

    private void OnTopScoreCollected()
    {
        BossLauncher boss = Instantiate(_bossTemplate, _spawnPoint.position, Quaternion.identity);
        boss.SetTarget(_player.transform);

        foreach (var objectPool in _objectPools)
        {
            objectPool.gameObject.SetActive(false);
        }
    }
}
