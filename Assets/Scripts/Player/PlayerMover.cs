using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _changeLineSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private Car _car;

    private Player _player;
    private BoxCollider2D _collider;
    private WaitForSeconds _jumpTimer;
    private Vector2 _heightValues;
    private Vector2 _startColliderOffset;
    private float _targetPositionY;
    private bool _isGrounded = true;
    private float _currentSpeed;
    public bool IsGrounded => _isGrounded;
    public float CurrentSpeed => _currentSpeed;

    [SerializeField] private UnityEvent _jumpStarted;
    [SerializeField] private UnityEvent _jumpFinished;
    [SerializeField] private UnityEvent _stopped;

    public event UnityAction<float, float> SpeedChanged;

    private void OnEnable()
    {
        _car.Launched += OnLaunched;
        _car.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _car.Launched -= OnLaunched;
        _car.Stopped -= OnStopped;
    }

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _heightValues = new Vector2(_stepSize, -_stepSize);

        _jumpTimer = new WaitForSeconds(_jumpDuration);
        _jumpStarted?.Invoke();

        _currentSpeed = _speed;
        _startColliderOffset = _collider.offset;

        _jumpFinished?.Invoke();
        _player = GetComponent<Player>();
        _player.Died += OnDied;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _currentSpeed * Time.deltaTime);

        if (transform.position.y != _targetPositionY)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _targetPositionY), _changeLineSpeed * Time.deltaTime);
        }
    }

    public IEnumerator Jump()
    {
        _collider.offset = new Vector2(_collider.offset.x, _jumpHeight);
        _isGrounded = false;
        _jumpStarted?.Invoke();

        yield return _jumpTimer;

        _jumpFinished?.Invoke();
        _collider.offset = _startColliderOffset;
        _isGrounded = true;
    }

    public void TryMoveUp()
    {
        if (_targetPositionY < _heightValues.x)
            _targetPositionY += _stepSize;
    }

    public void TryMoveDown()
    {
        if (_targetPositionY > _heightValues.y)
            _targetPositionY -= _stepSize;
    }

    public void Stop()
    {
        _currentSpeed = 0;
        _stopped?.Invoke();
    }

    private void OnDied()
    {
        _targetPositionY = 0;
    }

    private void OnLaunched(float speed)
    {
        SpeedChanged?.Invoke(_currentSpeed, speed);
        _currentSpeed = speed;
    }

    private void OnStopped()
    {
        SpeedChanged?.Invoke(_currentSpeed, _speed);
        _currentSpeed = _speed;
    }
}
