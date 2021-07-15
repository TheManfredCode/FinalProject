using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossMover))]
public class BossLauncher : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _launchDistance;

    private BossMover _boss;

    private void Start()
    {
        _boss = GetComponent<BossMover>();
    }

    private void Update()
    {
        if ((transform.position.x - _target.position.x) <= _launchDistance)
            _boss.Launch();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
