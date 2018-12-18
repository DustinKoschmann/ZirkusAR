using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBalance : MonoBehaviour {

    public float speed = 2.0f;
    public float rotateSpeed = 3.0f;

    private Animator animator;
    private CharacterController charController;
    private Vector3 forward;
    private float curSpeed;
    private float verticalMovement;
    private float horizontalMovement;

    private bool isWalking = false;

    // Use this for initialization
    void Start () {
        animator = this.transform.GetComponent<Animator>();
        charController = this.transform.GetComponent<CharacterController>();
	}

	
	// Update is called once per frame
	void Update () {
        verticalMovement = Input.GetAxis("Vertical");
        Debug.Log(verticalMovement);
        //horizontalMovement = Input.GetAxis("Horizontal");

        forward = transform.TransformDirection(Vector3.forward);
        curSpeed = speed * verticalMovement;

        if(verticalMovement > 0 || verticalMovement < 0) {
            isWalking = true;
            charController.SimpleMove(forward * curSpeed);
        } else if(verticalMovement == 0) {
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);
	}
}
