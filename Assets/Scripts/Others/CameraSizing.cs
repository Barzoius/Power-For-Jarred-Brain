using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizing : MonoBehaviour
{
    public SpriteRenderer sizeC;
    void Start()
    {
        float orthoSize = sizeC.bounds.size.x * Screen.height/Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
