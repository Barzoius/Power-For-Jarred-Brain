using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private List<SQuest> quests = new List<SQuest>();

    public static QuestManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void UnregisterItem(Item item)
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].QuestItem == item.scriptableItem)
            {
                Debug.Log("UnregisterItem");

        
                NPC targetNPC = FindNPCWithQuest(quests[i]);
                if (targetNPC != null)
                {
                    targetNPC.DecreaseQuestItem();
                }
            }
        }
    }


    private NPC FindNPCWithQuest(SQuest quest)
    {
        NPC[] allNPCs = FindObjectsOfType<NPC>();
        foreach (NPC npc in allNPCs)
        {
            if (npc.HasQuest(quest))
            {
                return npc; // Found the NPC with this quest
            }
        }
        return null;
    }



}
