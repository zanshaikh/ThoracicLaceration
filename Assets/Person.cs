using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public bool alive = true;
	CharacterController c;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!alive) {
			this.gameObject.renderer.enabled = false;			
		}
	}

	void Movement()
	{

	}
}
