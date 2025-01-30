using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private SNPC scriptableNPC;

    private bool playerInProximity = false;


    private List<string> dialogues = new List<string>();

    string currentLine;

    int currentIndex = 0;

    private Button nextB;

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
        currentLine = dialogues[currentIndex];

    }


    private void Update()
    {
        if (playerInProximity && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("FFFFFa");
            PickUp();
        }


    }


    public virtual void PickUp()
    {

        Destroy(gameObject);
        DisableNPCPrompt();
    }

    public virtual void ShowPrompt()
    {
        if (NPCsController.Instance != null)
        {
            NPCsController.Instance.ShowNPCPrompt(scriptableNPC.name,
                                                  scriptableNPC.description,
                                                  scriptableNPC.spriteImg,
                                                  dialogues[currentIndex]);

            NPCsController.Instance.getNextButton().onClick.RemoveAllListeners();

            NPCsController.Instance.getNextButton().onClick.AddListener(nextLine);
        }
    }


    public void nextLine()
    {
        Debug.Log("You have clicked the button!");

        if (currentIndex < dialogues.Count - 1) 
        {
            currentIndex++; 
            NPCsController.Instance.UpdateD(dialogues[currentIndex]); 
        }
    }

    public virtual void DisableNPCPrompt()
    {
        if (NPCsController.Instance != null)
        {
            NPCsController.Instance.DisablePrompt();
            NPCsController.Instance.getNextButton().onClick.RemoveAllListeners();
        }
    }
}
