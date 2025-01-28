using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Sitem scriptableItem;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = scriptableItem.spriteImg;
    }


    public virtual void PickUp()
    {
        Debug.Log("PickUp");
        if (PickUpController.Instance != null)
        {
            Debug.Log("PickUp");
            PickUpController.Instance.ShowItemPrompt(scriptableItem.name, 
                                                     scriptableItem.description,
                                                     scriptableItem.spriteImg);
        }
    }

}
