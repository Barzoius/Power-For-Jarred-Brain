using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "SQuest")]
public class SQuest : ScriptableObject
{
    public Sitem QuestItem;

    public int numItems;
}
