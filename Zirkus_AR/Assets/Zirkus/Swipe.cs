﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {
    private bool tap;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeDown;
    private bool swipeUp;
    private bool isDragging;

    private Vector2 startTouch;
    private Vector2 swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }
    public bool IsDragging { get { return isDragging; } }

    private void Update()
    {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        #region StandaloneInputs

        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs

        if(Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Did we cross the deadzone?
        if(swipeDelta.magnitude > 125)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //Up or Down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
