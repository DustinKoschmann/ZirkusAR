using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {

	public GameObject coupon;
	public GameObject[] games;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( (games[0].GetComponent<Image>().color == new Color32(220,111,111,255))
				&& (games[1].GetComponent<Image>().color == new Color32(220,111,111,255))
				&& (games[2].GetComponent<Image>().color == new Color32(220,111,111,255)) ) {
					
			StartCoroutine(End());
			
		}
		
	}
	
	IEnumerator End() {
		yield return new WaitForSeconds(2);
        GetComponent<Image>().color = new Color32(255,255,255,220);
		coupon.GetComponent<Image>().color = new Color32(255,255,255,220);
    }
}
