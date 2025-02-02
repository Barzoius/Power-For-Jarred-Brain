using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector2 startPos;

    Vector2 checkPos;

    SpriteRenderer spriteRenderer;

    PlayerBehaviour pb;

    Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        pb = GetComponent<PlayerBehaviour>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPos = transform.position;

        checkPos = transform.position;
    }



    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPos = pos;
    }


    IEnumerator Respawn(float duration)
    {
        rb.velocity = Vector3.zero;
        rb.simulated = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPos;
        spriteRenderer.enabled = true;
        if (pb != null)
        {
            pb.ResetPower();
        }
        rb.simulated = true;

    }
}
