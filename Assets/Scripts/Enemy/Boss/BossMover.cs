using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _changeLineSpeed;
    [SerializeField] private float _changeLineRate;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private float _currentSpeed = 0;
    private float _targetPositionY;
    private float _elapsedTime = 0;

    private void OnDisable()
    {
        _currentSpeed = 0;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _changeLineRate)
        {
            ChangeMoveLine();
            _elapsedTime = 0;
        }

        transform.Translate(Vector3.right * _currentSpeed * Time.deltaTime);

        if (transform.position.y != _targetPositionY)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _targetPositionY), _changeLineSpeed * Time.deltaTime);
        }
    }

    public void Launch()
    {
        _currentSpeed = _speed;
    }

    public void Stop()
    {
        _currentSpeed = 0;
    }

    private bool TryMoveUp()
    {
        if (_targetPositionY < _maxHeight)
        {
            _targetPositionY += _stepSize;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TryMoveDown()
    {
        if (_targetPositionY > _minHeight)
        {
            _targetPositionY -= _stepSize;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ChangeMoveLine()
    {
        bool isChangeReady = false;
        int tryMoveUpChance = 2;

        while(isChangeReady == false)
        {
            if (Random.Range(0, tryMoveUpChance) == 0)
                isChangeReady = TryMoveUp();
            else
                isChangeReady = TryMoveDown();
        }
    }
}
