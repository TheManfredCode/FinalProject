using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;
    [SerializeField] private Car _car;

    private List<GameObject> _pool = new List<GameObject>();
    private float _elapsedTime = 0;

    private void OnEnable()
    {
        if (_car != null)
        {
            _car.Launched += OnCarStarted;
            _car.Stopped += OnCarStopped;
        }
    }

    private void OnDisable()
    {
        if (_car != null)
        {
            _car.Launched -= OnCarStarted;
            _car.Stopped -= OnCarStopped;
        }
    }

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnRate)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPoitNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPoitNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    private void OnCarStarted(float speed)
    {
        foreach (var poolObject in _pool)
        {
            if (poolObject.TryGetComponent(out ObjectMover objectMover))
                objectMover.ChangeSpeed(speed);
        }
    }

    private void OnCarStopped()
    {
        foreach (var poolObject in _pool)
        {
            if (poolObject.TryGetComponent(out ObjectMover objectMover))
                objectMover.ResetSpeed();
        }
    }
}
