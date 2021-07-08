using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private List<GameObject> _pool = new List<GameObject>();
    private float _elapsedTime = 0;
    
    private void Start()
    {
        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            if (TryGetObject(out GameObject enemy))
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

    private void Initialize(GameObject[] templates)
    {
        int enemyTemplateIndex = 0;

        for (int i = 0; i < _capacity; i++)
        {
            //int enemyTemplateIndex = Random.Range(0, templates.Length);
            if (enemyTemplateIndex >= templates.Length)
                enemyTemplateIndex = 0;

            GameObject spawned = Instantiate(templates[enemyTemplateIndex], _container.transform);
            spawned.SetActive(false);
            enemyTemplateIndex++;

            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
