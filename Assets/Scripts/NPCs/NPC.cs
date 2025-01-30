using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private SNPC scriptableNPC;

    private bool playerInProximity = false;


    private List<string> dialogues = new List<string>();

    public void ChangePickable()
    {
        playerInProximity = !playerInProximity;
    }
    public bool GetPickable()
    {
        return playerInProximity;
    }

    private void Start()
    {

        dialogues = scriptableNPC.dialogues;
    }


    private void Update()
    {
        if (playerInProximity && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ADSDAS");
            PickUp();
        }
    }

    public virtual void PickUp()
    {

        Destroy(gameObject);
        DisableItemPrompt();
    }

    public virtual void ShowPrompt()
    {
        if (PickUpController.Instance != null)
        {
            PickUpController.Instance.ShowItemPrompt(scriptableNPC.name,
                                                     scriptableNPC.description,
                                                     scriptableNPC.spriteImg);
        }
    }

    public virtual void DisableItemPrompt()
    {
        if (PickUpController.Instance != null)
        {
            PickUpController.Instance.DisablePrompt();
        }
    }
}
