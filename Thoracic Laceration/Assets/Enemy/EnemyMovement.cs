using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private Vector3 newPos;
	public float speed = 35f;
	CharacterController c;
	Vector3 closestPos;
	Vector3 lastPosition;
	float minimumMovement = .05f;
	GameObject[] nodes;
	// Use this for initialization
	void Start () {
		c = transform.GetComponent<CharacterController> ();
	}

	Vector3 diffPos;
	Vector3 beforePos;
	// Update is called once per frame
	void Update () {

		nodes = GameObject.FindGameObjectsWithTag("Node");

	/*	foreach (GameObject n in nodes) {

			diffPos = n.transform.position - this.transform.position;
			diffPos *= diffPos;


		}*/

		c.Move(newPos);
		
		if (Vector3.Distance(transform.position, lastPosition) > minimumMovement)
		{
			lastPosition = transform.position;
			networkView.RPC("SetPosition", RPCMode.Others, transform.position);
		}
	}

	[RPC]
	void SetPosition(Vector3 newPosition)
	{
		transform.position = newPosition;
	}

}
