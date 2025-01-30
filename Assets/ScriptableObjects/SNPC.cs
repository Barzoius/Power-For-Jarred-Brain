using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


[CreateAssetMenu(fileName = "New NPC", menuName = "SNPC")]
public class SNPC : ScriptableObject
{

    public List<string> dialogues = new List<string>();

    public new string name;
    public string description;
    public Sprite spriteImg;

}
