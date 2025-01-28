using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Sitem", menuName = "Sitem")]
public class Sitem : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite spriteImg;
}
