using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Sitem scriptableItem;

    SpriteRenderer spriteRenderer;

    private bool pickable = false;

    public void ChangePickable()
    {
        pickable = !pickable;
    }
    public bool GetPickable()
    {
        return pickable;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = scriptableItem.spriteImg;

    }


    private void Update()
    {
        if (pickable && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    public virtual void PickUp()
    {

        QuestManager.Instance.UnregisterItem(this);
        Destroy(gameObject);
        Debug.Log("PickUp");
        DisableItemPrompt();
    }

    public virtual void ShowPrompt()
    {
        if (PickUpController.Instance != null)
        {
            PickUpController.Instance.ShowItemPrompt(scriptableItem.name,
                                                     scriptableItem.description,
                                                     scriptableItem.spriteImg);
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
