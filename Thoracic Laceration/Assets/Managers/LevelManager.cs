using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public int currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevel;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
		Application.LoadLevel (currentLevel + 1);
	}
}
