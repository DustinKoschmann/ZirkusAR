﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceController : MonoBehaviour {

	public GameObject artist;
	public GameObject finish;
    private MovementBalance movementBalance;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (artist.transform.position.z == finish.transform.position.z || artist.GetComponent<MovementBalance>().zielErreicht == true) {
			
			GetComponent<Image>().color = new Color32(220,111,111,255);
			
		}
	}
}
