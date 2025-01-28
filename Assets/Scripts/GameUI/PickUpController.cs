using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    public static PickUpController Instance { get; private set; }

    public GameObject itemPromptPrefab;

    [SerializeField]
    private float duration;

    private GameObject activePrompt;

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

        if (activePrompt == null)
        {
            activePrompt = Instantiate(itemPromptPrefab, transform);
            activePrompt.SetActive(false);
        }


        TMP_Text iName = activePrompt.transform.Find("item Name")?.GetComponent<TMP_Text>();
        TMP_Text iDesc = activePrompt.transform.Find("Item Description")?.GetComponent<TMP_Text>();
        Image iIcon = activePrompt.transform.Find("item Icon")?.GetComponent<Image>();

        if (iIcon)
            iIcon.sprite = icon;

        if (iName)
            iName.text = Name;

        if (iDesc)
            iDesc.text = Desc;


        activePrompt.SetActive(true);

    }

    public void DisablePrompt()
    {
        if (activePrompt != null) 
        {
            StopAllCoroutines(); 
            StartCoroutine(FadeOutPrompt(activePrompt));
        }
    }

    public void DeletePrompt()
    {
        if (activePrompt != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeOutPrompt(activePrompt));
            Destroy(activePrompt);
        }
    }

    private IEnumerator FadeOutPrompt(GameObject prompt)
    {
        yield return new WaitForSeconds(duration);

        if (prompt == null) yield break;

        CanvasGroup cg = prompt.GetComponent<CanvasGroup>();

        for(float timePassed = 0f; timePassed < 1f; timePassed += Time.deltaTime)
        {
            if (prompt == null) yield break;

            cg.alpha = 1f - timePassed;

            yield return null;

        }
        prompt.SetActive(false);

    }
}
