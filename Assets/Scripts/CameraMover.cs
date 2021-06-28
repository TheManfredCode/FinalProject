using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    
    private void Update()
    {
        transform.Translate(Vector3.right * _playerMover.Speed * Time.deltaTime);
    }
}
