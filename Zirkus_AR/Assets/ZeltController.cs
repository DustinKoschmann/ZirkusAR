using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeltController : MonoBehaviour {

	public GameObject zelt;
	public GameObject check;
	
	public GameObject infoEintrittButton;
	public GameObject infoEintritt;
	private bool infoEintrittCheck;
	
	public GameObject infoZeltButton;
	public GameObject infoZelt;
	private bool infoZeltCheck;
	
	private Vector3 startPos;
	private bool checking;
	private bool done;

	// Use this for initialization
	void Start () {
		
		infoEintrittCheck = false;
		infoZeltCheck = false;
		
		done = false;
		checking = false;
		startPos = zelt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(startPos != zelt.transform.position && checking == false) {
			
			infoEintrittButton.SetActive(true);
			infoZeltButton.SetActive(true);
			checking = true;
			
		}
		
		if(infoEintrittCheck == true && infoZeltCheck == true && done == false) {
			
			done = true;
			GetComponent<Image>().color = new Color32(220,111,111,255);
			infoEintrittButton.SetActive(false);
			infoZeltButton.SetActive(false);
			// StartCoroutine(isDoneZelt());
			
		}
		
	}
	
	public void infoEintrittGame () {
		
		infoEintritt.SetActive(true);
		
	}
	
	public void infoEintrittGameClose () {
		
		infoEintritt.SetActive(false);
		infoEintrittCheck = true;
		
	}
	
	public void infoZeltGame () {
		
		infoZelt.SetActive(true);
		
	}
	
	public void infoZeltGameClose () {
		
		infoZelt.SetActive(false);
		infoZeltCheck = true;
		
	}
	
	/* IEnumerator isDoneZelt() {
		yield return new WaitForSeconds(0.5f);
		check.SetActive(true);
		yield return new WaitForSeconds(3);
        check.SetActive(false);
    } */
}
