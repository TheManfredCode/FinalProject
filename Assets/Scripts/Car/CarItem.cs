using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out StateSwitcher stateSwitcher) && collision.TryGetComponent(out DriveState driveState))
        {
            stateSwitcher.SwitchState(driveState);
            Destroy(gameObject);
        }
    }
}
