using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDropper : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bomb _bombTemplate;
    [SerializeField] private RocketMover _rocketTemplate;
    [SerializeField] private int _rocketDropChance = 5;
    [SerializeField] private float _dropRate;
    [SerializeField] private Transform _dropPoint;

    private float _elapsedTime = 0;
    private int _maxDropChance = 100;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _dropRate)
        {
            if(Random.Range(0, _maxDropChance) <= _rocketDropChance)
            {
                RocketMover rocket = Instantiate(_rocketTemplate, _dropPoint.position, Quaternion.identity);
                rocket.Launch(_target.position);
            }
            else
            {
                Instantiate(_bombTemplate, _dropPoint.position, Quaternion.identity);
            }

            _elapsedTime = 0;
        }
    }
}
