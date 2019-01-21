using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceController : MonoBehaviour {

	public GameObject artist;
	public GameObject finish;
	public GameObject check;
    private MovementBalance movementBalance;
	private bool done;
	
	// Use this for initialization
	void Start () {
		done = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (artist.transform.position.z == finish.transform.position.z || artist.GetComponent<MovementBalance>().zielErreicht == true) {
			if (done == false) {
				done = true;
				GetComponent<Image>().color = new Color32(220,111,111,255);
				// StartCoroutine(isDone());
			}
		}
	}
	
	/* IEnumerator isDone() {
		yield return new WaitForSeconds(0.5f);
		check.SetActive(true);
		yield return new WaitForSeconds(3);
        check.SetActive(false);
    } */
}
