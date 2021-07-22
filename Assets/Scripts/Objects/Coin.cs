using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.TakeReward(_reward);
            Destroy(gameObject);
        }
        if(collision.TryGetComponent(out Edge edge))
        {
            Destroy(gameObject);
        }
    }
}
