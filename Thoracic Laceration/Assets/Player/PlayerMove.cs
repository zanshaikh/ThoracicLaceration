using UnityEngine;
using System.Collections;

public class PlayerMove : Person {
	//CharacterController c;
	public Vector3 newPos = new Vector3(-39.68812f, -39.15045f, -0.587138f);
	
	void Start () {
		//c = transform.GetComponent<CharacterController> ();
		newPos.x = transform.localPosition.x;

	}

	void Update () {
		if (Input.GetAxis ("Horizontal") == 1) {
			newPos.x += 0.25f;		
		}
		if (Input.GetAxis ("Horizontal") == -1) {
			newPos.x -= 0.25f;
		}
		if (Input.GetAxis ("Vertical") == 1) {
			newPos.y += 0.25f;		
		}
		if (Input.GetAxis ("Vertical") == -1) {
			newPos.y -= 0.25f;
		}
		//c.Move (newPos);
		transform.localPosition = newPos;
	
	}
}
