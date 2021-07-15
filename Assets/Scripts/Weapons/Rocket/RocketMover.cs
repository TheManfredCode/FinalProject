using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target = new Vector3(0, 0, 0);

    private void Update()
    {
        if(transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Launch(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _target = target;
    }
}
