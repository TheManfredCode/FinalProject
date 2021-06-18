using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] protected int Damage;

    protected int Direction;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed * Direction, Space.Self);
    }
}
