using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private float startPos;
    private float length;
    public GameObject cam;
    public float parallaxEffect;

    [SerializeField]
    private float padding = 1f;

    void Start()
    {
     

        startPos = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

 
    void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallaxEffect);

        float movement = (cam.transform.position.x * (1 - parallaxEffect)) - padding;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
