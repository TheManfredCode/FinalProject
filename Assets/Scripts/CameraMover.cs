using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        transform.Translate(Vector3.right * _playerMover.CurrentSpeed * Time.deltaTime);
    }

    public void Restart()
    {
        Vector3 newCameraPosition = new Vector3((_playerMover.transform.position.x + _offsetX), transform.position.y, transform.position.z);

        transform.position = newCameraPosition;
    }
}
