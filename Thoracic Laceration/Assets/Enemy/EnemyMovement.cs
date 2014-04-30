using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private Vector3 newPos;
	public float speed = 35f;
	CharacterController c;
	Vector3 lastPosition;
	float minimumMovement = .05f;

	// Use this for initialization
	void Start () {
		c = transform.GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {

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
