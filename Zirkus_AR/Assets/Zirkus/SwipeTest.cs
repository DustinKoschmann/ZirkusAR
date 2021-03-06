﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {
    public Transform ballPrefab;
    public Swipe swipeControls;

    private Transform parentObject;
    private Transform ball;
    private Rigidbody ballRb;

    private void Start()
    {
        parentObject = this.transform.parent;
    }

    // Update is called once per frame
    void Update () {
        if (swipeControls.Tap)
        {
            if(swipeControls)
            ball = Instantiate(ballPrefab, this.transform.position, this.transform.rotation, parentObject);
            //ball.transform.localScale = new Vector3(.4f, .4f, .4f);
            ballRb = ball.GetComponent<Rigidbody>();
        }
        if(swipeControls.SwipeUp)
        {
            ballRb.isKinematic = false;
            ballRb.AddForce(Vector3.forward * 14f, ForceMode.Impulse);
        }
	}
}
