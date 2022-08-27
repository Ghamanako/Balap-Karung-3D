using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public GameObject player;
    private Vector2 startPos;
    public int PixelDistTodetect=20;
    private bool fingerDown;

    

    // Update is called once per frame
    void Update()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase==TouchPhase.Began)
        {

        }
    }
}
