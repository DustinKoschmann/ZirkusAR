using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DosenController : MonoBehaviour {

	public GameObject[] dosen;
	public GameObject check;
	private int counter;
	private bool done;

	// Use this for initialization
	void Start () {
		counter = 0;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Wenn counter auf 6, dann färbe ein
		if (dosen.Length == counter && done == false) {
			done = true;
			GetComponent<Image>().color = new Color32(220,111,111,255);
			// StartCoroutine(isDone());
		}
		
		//Debug.Log (counter);
		try {
            // Wenn die Dose runtergefallen ist, dann counter++
            for (int i = 0; counter < 6; i++) {
                if (dosen[i] != null && dosen[i].transform.position.y < -20) {
                    counter = counter + 1;
                    Destroy(dosen[i]);
                }
            }
        } catch {

        }
		
	}
	
	/* IEnumerator isDone() {
		yield return new WaitForSeconds(0.5f);
		check.SetActive(true);
		yield return new WaitForSeconds(3);
        check.SetActive(false);
    } */
}
