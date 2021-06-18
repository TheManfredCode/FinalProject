using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;

    private BoxCollider2D _collider;
    private Vector3 _targetPosition;
    private WaitForSeconds _jumpTimer;
    private Vector2 _startColliderOffset;
    private bool _isGrounded = true;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _targetPosition = transform.position;

        _jumpTimer = new WaitForSeconds(_jumpDuration);
        _startColliderOffset = _collider.offset;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public IEnumerator Jump()
    {
        _collider.offset = new Vector2(_collider.offset.x, _jumpHeight);
        _isGrounded = false;

        yield return _jumpTimer;

        _collider.offset = _startColliderOffset;
        _isGrounded = true;
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHeight)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if(_targetPosition.y > _minHeight)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
