using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPCInteract : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("NPC"))
        {

            NPC npc = collision.GetComponent<NPC>();


            if (npc != null)
            {
                npc.ChangePickable();
                npc.ShowPrompt();
            }

        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.CompareTag("NPC"))
        {

            NPC npc = collision.GetComponent<NPC>();


            if (npc != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("DAS");
                    npc.PickUp();

                }
            }

        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPC npc = collision.GetComponent<NPC>();



            if (npc != null)
            {
                npc.ChangePickable();
                npc.DisableNPCPrompt();

            }
        }
    }
}
