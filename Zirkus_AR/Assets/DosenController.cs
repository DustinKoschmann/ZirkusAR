using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DosenController : MonoBehaviour {

	public GameObject[] dosen;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Wenn counter auf 6, dann färbe ein
		if (dosen.Length == counter) {
			GetComponent<Image>().color = new Color32(220,111,111,255);
		}
		
		Debug.Log (counter);
		
		// Wenn die Dose runtergefallen ist, dann counter++
		for (int i = 0; counter < 6; i++) {
			if (dosen[i] != null && dosen[i].transform.position.y < -20) {
				counter = counter + 1;
				Destroy (dosen[i]);
			}
		}
	}
}
