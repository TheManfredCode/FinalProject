using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _changeLineSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private Car _car;

    private float _speed;
    private BoxCollider2D _collider;
    private float _targetPositionY;
    private WaitForSeconds _jumpTimer;
    private Vector2 _startColliderOffset;
    private bool _isGrounded = true;

    public bool IsGrounded => _isGrounded;
    public float Speed => _speed;

    private void OnEnable()
    {
        _car.Launched += OnCarLaunched;
        _car.Stopped += OnCarStopped;
    }

    private void OnDisable()
    {
        _car.Launched -= OnCarLaunched;
        _car.Stopped -= OnCarStopped;
    }

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _jumpTimer = new WaitForSeconds(_jumpDuration);

        _speed = _startSpeed;
        _startColliderOffset = _collider.offset;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.y != _targetPositionY)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _targetPositionY), _changeLineSpeed * Time.deltaTime);
        }
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
        if (_targetPositionY < _maxHeight)
            _targetPositionY += _stepSize;
    }

    public void TryMoveDown()
    {
        if (_targetPositionY > _minHeight)
            _targetPositionY -= _stepSize;
    }

    private void OnCarLaunched(float speed)
    {
        _speed = speed;
    }

    private void OnCarStopped()
    {
        _speed = _startSpeed;
    }
}
