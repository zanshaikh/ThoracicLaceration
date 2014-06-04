using UnityEngine;
using System.Collections;

public class LaserBox : MonoBehaviour {
	GameObject[] g;
	int counter = 0;

	// Use this for initialization
	void Start () {
		g = GameObject.FindGameObjectsWithTag ("Laser");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		for (int i = 0; i < g.Length; i++) {
			g[i].SetActive(false);
		}
		StartCoroutine (ReturnAfterSec());
	}
	IEnumerator ReturnAfterSec(){
		yield return new WaitForSeconds (5f);
		for (int i = 0; i < g.Length; i++) {
			g[i].SetActive(true);
	}
}
}
