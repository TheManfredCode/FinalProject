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

    protected List<GameObject> Pool => _pool;
    
    private void Awake()
    {
        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            if (TryGetObject(out GameObject poolObject))
            {
                _elapsedTime = 0;

                int spawnPoitNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(poolObject, _spawnPoints[spawnPoitNumber].position);
            }
        }
    }

    private void SetObject(GameObject poolObject, Vector3 spawnPoint)
    {
        poolObject.SetActive(true);
        poolObject.transform.position = spawnPoint;
    }

    private void Initialize(GameObject[] templates)
    {
        int objectTemplateIndex = 0;

        for (int i = 0; i < _capacity; i++)
        {
            if (objectTemplateIndex >= templates.Length)
                objectTemplateIndex = 0;

            GameObject spawned = Instantiate(templates[objectTemplateIndex], _container.transform);
            spawned.SetActive(false);
            objectTemplateIndex++;

            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
