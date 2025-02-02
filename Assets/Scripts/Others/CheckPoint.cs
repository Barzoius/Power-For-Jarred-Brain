using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerManager pm;


    public GameObject player;

    private void Awake()
    {
        pm = player.GetComponent<PlayerManager>();



        if (pm == null)
        {
            Debug.Log("ASD");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.CompareTag("PlayerHitBox"))
        {
            Debug.Log("ChekPoint");
            pm.UpdateCheckPoint(transform.position);
            
        }
    }
}
