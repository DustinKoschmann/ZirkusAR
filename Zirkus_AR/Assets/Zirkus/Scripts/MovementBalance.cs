using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBalance : MonoBehaviour {
    private bool isWalking = false;
    private bool firedOnce = false;
    public  bool zielErreicht = false;
    private bool isBalanced = false;
    private float speed = 0.1f;
    private float horizontalMovement;
    private int actualTarget;

    private Transform parentTarget;
    private Transform[] targets;
    private Animator animator;
    private Transform boneToRotate;

    // Use this for initialization
    void Start () {
        actualTarget = 0;
        animator = this.transform.GetComponent<Animator>();
        boneToRotate = this.transform.Find("metarig/hips/spine");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0) {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width/2) {
                horizontalMovement = 1;
            } else if (touch.position.x > Screen.width/2) {
                horizontalMovement = -1;
            }
        } else if (Input.touchCount <= 0) {
            horizontalMovement = 0;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (Input.mousePosition.x < Screen.width/2) {
                horizontalMovement = 1;
            } else if (Input.mousePosition.x > Screen.width/2) {
                horizontalMovement = -1;
            }
        } else if (Input.GetMouseButtonUp(0)) {
            horizontalMovement = 0;
        }

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

            if (!zielErreicht && isBalanced) {
                isWalking = true;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targets[actualTarget].position, step);
            } else {
                isWalking = false;
            }
            animator.SetBool("isWalking", isWalking);
            BalanceBone();
        }
	}
    void BalanceBone() {
        if (boneToRotate != null) {
            Vector3 boneRot = boneToRotate.localEulerAngles;
            //Debug.Log(boneRot.z);
            //Debug.Log(horizontalMovement);
            boneToRotate.localEulerAngles += new Vector3(0, 0, horizontalMovement);

            //Wenn der Bone eine gerade Rotation hat. (40° Spielraum)
            if ((boneRot.z >= 340 && boneRot.z <= 360) || (boneRot.z >= 0 && boneRot.z <= 20)) {
                isBalanced = true;
            } else {
                isBalanced = false;
            }
            
            if (!zielErreicht) {
                //Wenn in Linksneigung, rotier weiter nach links
                if (boneRot.z > 0 && boneRot.z < 180 && horizontalMovement >= 0) {
                    boneToRotate.localEulerAngles += new Vector3(0, 0, 1f);
                }

                //Wenn zu weit nach links, nicht weiter rotieren
                if (boneRot.z > 100 && boneRot.z < 180) {
                    boneToRotate.localEulerAngles = new Vector3(0, 0, 100f);
                }

                //Wenn in Rechtsneigung, rotier weiter nach rechts
                if (boneRot.z > 180 && boneRot.z < 360 && horizontalMovement <= 0) {
                    boneToRotate.localEulerAngles += new Vector3(0, 0, -1f);
                }

                //Wenn zu weit nach rechts, nicht weiter rotieren
                if (boneRot.z < 260 && boneRot.z > 180) {
                    boneToRotate.localEulerAngles = new Vector3(0, 0, 260f);
                }
            }
            
        }
    }
}
