using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Die();

        if(collision.TryGetComponent(out Edge edge))
            gameObject.SetActive(false);
    }
}
