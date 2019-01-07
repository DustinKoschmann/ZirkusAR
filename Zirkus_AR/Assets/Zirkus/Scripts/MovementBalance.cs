using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBalance : MonoBehaviour {
    private int actualTarget;
    private bool isWalking = false;
    private float speed = 0.1f;
    private Transform parentTarget;
    private Transform[] targets;
    private Animator animator;
    private bool firedOnce = false;
    private bool zielErreicht = false;

    // Use this for initialization
    void Start () {
        actualTarget = 0;
        animator = this.transform.GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void Update () {
        if (!firedOnce) {
            try {
                parentTarget = GameObject.Find("Targets").transform;
            } catch { }      
            
            if(parentTarget != null) {
                firedOnce = true;
            }

            Transform[] children = {
                parentTarget.GetChild(0),
                parentTarget.GetChild(1),
                parentTarget.GetChild(2),
                parentTarget.GetChild(3),
                parentTarget.GetChild(4)
            };

            targets = children;
            Debug.Log(targets.Length);
        } else {
            if (actualTarget >= targets.Length - 1) {
                zielErreicht = true;
            }

            if ((transform.position == targets[actualTarget].position) && !zielErreicht) {
                actualTarget++;
            }            

            if(!zielErreicht) {
                isWalking = true;
            } else {
                isWalking = false;
            }
            animator.SetBool("isWalking", isWalking);



            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targets[actualTarget].position, step);
        }
	}
}
