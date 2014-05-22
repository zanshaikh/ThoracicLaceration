using UnityEngine;
using System.Collections;

public class LaserManager : MonoBehaviour {
	public bool isOn;

	// Use this for initialization
	void Start () {
		isOn = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (isOn = true) {
			Destroy(other.gameObject);
		}

	}
	public void setIsOnToOff(){
		isOn = false;
		renderer.enabled = false;
		enabled = false;

	}


}
