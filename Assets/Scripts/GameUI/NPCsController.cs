using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCsController : MonoBehaviour
{
    // Start is called before the first frame update
    public static NPCsController Instance { get; private set; }

    public GameObject npcPromptPrefab;

    [SerializeField]
    private float duration;

    private GameObject activePrompt;

    TMP_Text iLine;

    Button nextB;

    public void Awake()
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



    public Button getNextButton()
    {
      if(nextB != null)
            return nextB;
      else
            return nextB;

     
    }

    public void ShowNPCPrompt(string Name, string Desc, Sprite icon, string Line)
    {

        if (activePrompt == null)
        {
            activePrompt = Instantiate(npcPromptPrefab, transform);
            activePrompt.SetActive(false);
        }


        TMP_Text iName = activePrompt.transform.Find("NPC Name")?.GetComponent<TMP_Text>();
        TMP_Text iDesc = activePrompt.transform.Find("Item Description")?.GetComponent<TMP_Text>();
        Image iIcon = activePrompt.transform.Find("NPC Icon")?.GetComponent<Image>();


        TMP_Text iLine = activePrompt.transform.Find("Dialogue")?.GetComponent<TMP_Text>();

        nextB = activePrompt.transform.Find("nextButton")?.GetComponent<Button>();


        if (iIcon)
            iIcon.sprite = icon;

        if (iName)
            iName.text = Name;

        if (iDesc)
            iDesc.text = Desc;

        if(iLine)
            iLine.text = Line;


        activePrompt.SetActive(true);

    }

    public void UpdateD(string Line)
    {
        if (activePrompt == null)
        {
            activePrompt = Instantiate(npcPromptPrefab, transform);
            activePrompt.SetActive(false);
        }

        TMP_Text iLine = activePrompt.transform.Find("Dialogue")?.GetComponent<TMP_Text>();

        nextB = activePrompt.transform.Find("nextButton")?.GetComponent<Button>();

        if (iLine)
            iLine.text = Line;


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

        for (float timePassed = 0f; timePassed < 1f; timePassed += Time.deltaTime)
        {
            if (prompt == null) yield break;

            cg.alpha = 1f - timePassed;

            yield return null;

        }

        prompt.SetActive(false);
        cg.alpha = 1f;

    }
}
