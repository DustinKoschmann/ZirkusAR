using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {
    public Swipe swipeControls;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		if(swipeControls.SwipeUp)
        {
            rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        }
	}
}
