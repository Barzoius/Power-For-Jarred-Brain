using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private PlayerManager player;

    void Start()
    {
        player = GetComponentInParent<PlayerManager>();

        if (player == null)
        {
            Debug.LogError("PlayerManager script not found on parent!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            player.Die();
        }
    }
}
