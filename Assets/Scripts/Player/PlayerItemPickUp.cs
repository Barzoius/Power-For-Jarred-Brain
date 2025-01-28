using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();

            

            if(item != null)
            {

                Debug.Log("co");
                item.PickUp();
                //Destroy(item.gameObject);

            }
        }
    }

    
}
