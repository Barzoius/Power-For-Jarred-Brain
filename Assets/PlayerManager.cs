using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector2 startPos;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPos = transform.position;
    }



    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }


    IEnumerator Respawn(float duration)
    {
        rb.velocity = Vector3.zero;
        rb.simulated = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        spriteRenderer.enabled = true;
        rb.simulated = true;

    }
}
