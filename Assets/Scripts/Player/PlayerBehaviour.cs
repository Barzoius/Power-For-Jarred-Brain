using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jump;

    [SerializeField]
    private int powerCap;

    [SerializeField]
    private int power;

    private float move;

    private Rigidbody2D rb;

    [SerializeField]
    private bool onWheels=false;

    private float powerTimer = 0f;

    private float powerDecreaseInterval = 1f;

    public TMP_Text energyText;


    public AudioSource audioSource;


    public void GiveWeels()
    {
        onWheels = true;
    }

    public void ResetPower()
    {
        power = powerCap;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); 
        }
    }
    void Update()
    {
        energyText.text = "Power: " + power;

        move = Input.GetAxis("Horizontal");

        if (power <= 0)
        {
            gameObject.GetComponent<PlayerManager>().Die();
        }

        if (onWheels)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            if (Mathf.Abs(move) > 0.1f) // Ensure the player is moving
            {
                powerTimer += Time.deltaTime;

                if (powerTimer >= powerDecreaseInterval)
                {
                    power -= 1;
                    powerTimer = 0f; // Reset timer
                }
            }
            else
            {
                powerTimer = 0f; // Reset timer if not moving
            }
        }


        if (Input.GetButtonDown("Jump") && power > 0)
        {

            audioSource.Play();

            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            rb.AddForce(new Vector2(rb.velocity.x, jump));
            power -= 20;
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Battery"))
        {

            power = powerCap;

            Destroy(collision.gameObject);

        }

        if (collision.CompareTag("End"))
        {

            LoadEndScene();
        }


    }


    void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

}
