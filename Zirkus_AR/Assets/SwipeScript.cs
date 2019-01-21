using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour {
	
    public Transform ballPrefab;
    // public Transform fakeBallPrefab;
    public Transform parentObject;

    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInXandY = 0.5f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 80f; // to control throw force in Z direction
	
	private Rigidbody rbBall;
    private Transform ball;
    // private Transform fakeBall;
    

    void Start()
	{
	
	}

	// Update is called once per frame
	void Update () {
        MobileTouch();
		MouseDebugTouch();
	}

    void MobileTouch() {
        // if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            // SpawnFakeBall();

            // getting touch position and marking time when you touch the screen
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        // if you release your finger
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {

            // marking time when you release it
            touchTimeFinish = Time.time;

            // getting release finger position
            endPos = Input.GetTouch(0).position;

            ThrowBall();
        }
    }

    void MouseDebugTouch() {
        // if you click the screen
        if(Input.GetMouseButtonDown(0)) {
            // SpawnFakeBall();
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        // if you release your mouse
        if (Input.GetMouseButtonUp(0)) {

            // marking time when you release it
            touchTimeFinish = Time.time;

            // getting release mouse position
            endPos = Input.mousePosition;

            ThrowBall();
        }
    }

    /* void SpawnFakeBall() {
        fakeBall = Instantiate(fakeBallPrefab, this.transform.position, this.transform.rotation, parentObject);
    } */

    /* void RemoveFakeBall() {
        Destroy(fakeBall.gameObject);
    }*/

    void ThrowBall() {
        // RemoveFakeBall();

        // calculate swipe time interval 
        timeInterval = touchTimeFinish - touchTimeStart;

        // calculating swipe direction in 2D space
        direction = startPos - endPos;

        // spawn ball and add force to it
        ball = Instantiate(ballPrefab, this.transform.position, this.transform.rotation, parentObject);
        ball.GetComponent<Rigidbody>().AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);
        Destroy(ball.gameObject, 2f);
    }
}
