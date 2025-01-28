using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    public static PickUpController Instance { get; private set; }

    public GameObject itemPromptPrefab;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowItemPrompt(string Name, string Desc, Sprite icon)
    {
        GameObject newPrompt = Instantiate(itemPromptPrefab, transform);


        TMP_Text iName = newPrompt.transform.Find("item Name")?.GetComponent<TMP_Text>();
        TMP_Text iDesc = newPrompt.transform.Find("Item Description")?.GetComponent<TMP_Text>();

        Image iIcon = newPrompt.transform.Find("item Icon")?.GetComponent<Image>();

        if(iIcon)
            iIcon.sprite = icon;

        if (iName)
            iName.text = Name;

        if(iDesc)
            iDesc.text = Desc;
            

    }
}
