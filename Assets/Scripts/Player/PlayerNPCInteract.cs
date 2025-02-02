using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPCInteract : MonoBehaviour
{
    private NPC currentNPC;  // Track the NPC in range
    private bool isNearNPC = false;

    private void Update()
    {
        if (isNearNPC && Input.GetKeyDown(KeyCode.E) && currentNPC != null)
        {
            currentNPC.ShowPrompt();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            currentNPC = collision.GetComponent<NPC>();
            isNearNPC = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (currentNPC != null)
            {
                currentNPC.ChangePickable();
                currentNPC.DisableNPCPrompt();
            }
            isNearNPC = false;
            currentNPC = null;
        }
    }
}
