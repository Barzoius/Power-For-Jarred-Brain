using System;
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


    int currentIndex = 0;


    private int indexCap;

    private int questItems;

    public bool questFinsihed;

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

        indexCap = scriptableNPC.completionIndex;

        questItems = scriptableNPC.quest.numItems;

    }


    private void Update()
    {
        if (questItems == 0)
        {
            indexCap = scriptableNPC.dialogues.Count - 1;
        }


        if (currentIndex == dialogues.Count - 2)
        {
            Debug.Log("Quest Finsihed");
            questFinsihed = true;
        }

    }
    public bool HasQuest(SQuest quest)
    {
        return scriptableNPC.quest == quest;
    }

    public void DecreaseQuestItem()
    {
        if (questItems > 0)
        {
            questItems--;  
            Debug.Log($"NPC {scriptableNPC.name} now has {questItems} items left.");
        }
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

        if (currentIndex < indexCap - 1) 
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
            NPCsController.Instance.getNextButton()?.onClick.RemoveAllListeners();
        }
    }
}
