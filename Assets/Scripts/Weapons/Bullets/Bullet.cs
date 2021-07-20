using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public float Speed => _speed;
    public int Damage => _damage;

    protected int Direction;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed * Direction, Space.Self);
    }
}
