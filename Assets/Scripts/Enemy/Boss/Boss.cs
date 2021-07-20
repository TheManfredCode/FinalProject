using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : ArmedEnemy
{
    public event UnityAction Died;

    protected override void Die()
    {
        Died?.Invoke();
    }
}
