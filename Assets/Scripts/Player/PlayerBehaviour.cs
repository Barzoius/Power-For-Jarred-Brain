using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && power > 0)
        {

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


    }
}
