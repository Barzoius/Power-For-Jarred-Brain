using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerItemPickUp : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Item"))
        {

            Item item = collision.GetComponent<Item>();

            
            if(item != null)
            {
                item.ChangePickable();
                item.ShowPrompt();
            }

        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.CompareTag("Item"))
        {

            Item item = collision.GetComponent<Item>();


            if (item != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("DAS");
                    item.PickUp();

                }
            }

        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();



            if (item != null)
            {
                item.ChangePickable();
                item.DisableItemPrompt();

            }
        }
    }


}
