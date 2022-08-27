using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, SwipeRight, SwipeUp, SwipeDown;
    private bool IsDragging = false;
    private Vector2 StartTouch, SwipeDelta;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        tap = SwipeDown = SwipeUp = swipeLeft = SwipeRight = false;
        #region standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            IsDragging = true;
            StartTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            Reset();
        }
        #endregion


        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                IsDragging = true;
                StartTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDragging = false;
                Reset();
            }
        }
        #endregion

        //calculate the distance
        SwipeDelta = Vector2.zero;
        if (IsDragging)
        {
            if (Input.touches.Length < 0)
                SwipeDelta = Input.touches[0].position - StartTouch;
            else if (Input.GetMouseButton(0))
                SwipeDelta = (Vector2)Input.mousePosition - StartTouch;
        }

        //did we cross the distance
        if (SwipeDelta.magnitude > 125)
        {
            //which direction?
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;
            if(Mathf.Abs(x)> Mathf.Abs(y))
            {
                //left or right 
                if (x < 0)
                    swipeLeft = true;
                else
                    SwipeRight = true;
            }
            else
            {
                //up or down
                if (y < 0)
                    SwipeDown = true;
                else
                    SwipeUp = true;
             
            }
            Reset();
        }

    }

    public void Reset()
    {
        StartTouch=SwipeDelta=Vector2.zero;
        IsDragging = false;
    }

    
}
