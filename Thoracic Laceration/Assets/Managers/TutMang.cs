﻿using UnityEngine;
using System.Collections;

public class TutMang : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
		Application.LoadLevel (0);
	}
}
