using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private float startPos;
    private float length;
    public GameObject cam;
    public float parallaxEffect;


    void Start()
    {
     

        startPos = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

 
    void FixedUpdate()
    {
        float distance = ((cam.transform.position.x) * parallaxEffect);

        float movement = ((cam.transform.position.x) * (1 - parallaxEffect));

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        float buffer = 0.5f * length; 

        if (movement > startPos + length - buffer) // Reset earlier
        {
            startPos += length;
        }
        else if (movement < startPos - length + buffer) // Reset earlier
        {
            startPos -= length;
        }
    }
}
