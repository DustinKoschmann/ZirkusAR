using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DosenScript : MonoBehaviour {
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.transform.GetComponent<Rigidbody>();
        //rb.isKinematic = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision) {
        if(rb.isKinematic == true) {
            rb.isKinematic = false;
        }
    }
}
