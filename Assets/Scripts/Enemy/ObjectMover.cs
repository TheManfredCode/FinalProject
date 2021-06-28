using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _speed;

    public float Speed => _speed;

    private void Awake()
    {
        _speed = _startSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    public void ResetSpeed()
    {
        _speed = _startSpeed;
    }
}
