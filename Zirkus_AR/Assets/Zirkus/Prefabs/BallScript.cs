﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision col) {
        col.transform.GetComponent<Rigidbody>().isKinematic = false;
    }
}
