using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour {

	public GameObject anleitung;
	private bool isOpen;


	// Use this for initialization
	void Start () {
		isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void showMenu () {
		
		if (isOpen == false) {
			anleitung.SetActive(true);
			isOpen = true;
		} else {
			anleitung.SetActive(false);
			isOpen = false;
		}
		
	}
}
