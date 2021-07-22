using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CarActivator carSwitcher))
        {
            carSwitcher.LaunchCar();
            gameObject.SetActive(false);
        }
        if(collision.TryGetComponent(out Edge edge))
        {
            gameObject.SetActive(false);
        }
    }
}
