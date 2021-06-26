using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public abstract class State : MonoBehaviour
{
    protected PlayerInput PlayerInput;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    public void Enter()
    {
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
    }
}
