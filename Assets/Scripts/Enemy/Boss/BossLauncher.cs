using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boss))]
[RequireComponent(typeof(BossMover))]
public class BossLauncher : MonoBehaviour
{
    [SerializeField] private float _launchDistance;

    private Transform _target;
    private Boss _boss;
    private BossMover _bossMover;

    private void Start()
    {
        _boss = GetComponent<Boss>();
        _bossMover = GetComponent<BossMover>();

        _target = _boss.Target.transform;
    }

    private void Update()
    {
        if ((transform.position.x - _target.position.x) <= _launchDistance)
            _bossMover.Launch();
    }
}
