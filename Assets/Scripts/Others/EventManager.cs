using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class is a very bad way oh handling events but i didnt have time for soemthing else

public class EventManager : MonoBehaviour
{

    public GameObject player;

    public GameObject gate;
    public GameObject lever;
    private Animator gateAnim;

    private SpriteRenderer playerSprite; 

    public Sprite newPlayerSprite;

    public Sprite newOzySprite;
    public Sprite newLeverSprite;

    public GameObject ozy;
    public GameObject drud;

    private NPC drudNPC;
    private NPC ozyNPC;

    private void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();

        drudNPC = drud.GetComponent<NPC>();
        ozyNPC = ozy.GetComponent<NPC>();

        gateAnim = gate.GetComponent<Animator>();

    }

    private void Update()
    {
        if(ozyNPC.questFinsihed == true)
        {
            gateAnim.SetBool("OpenGate", true);

            ozy.GetComponent<SpriteRenderer>().sprite = newOzySprite;

            lever.GetComponent<SpriteRenderer>().sprite = newLeverSprite;
        }


        if (drudNPC.questFinsihed == true)
        {
            playerSprite.sprite = newPlayerSprite;
            player.GetComponent<PlayerBehaviour>().GiveWeels();
        }

    }
}
