using UnityEngine;
using System.Collections;

public class ANetworkingScript : MonoBehaviour {

	public string connectionIP = "127.0.0.1";
	public int connectionPort = 25001;
	private Vector3 newPos;
	public float speed = 35f;
	CharacterController c;
	// Use this for initialization
	void Start () {
		c = transform.GetComponent<CharacterController> ();
		newPos = new Vector3 (0f, 0f, 0f);	
	}

	Vector3 lastPosition;
	float minimumMovement = .05f;

	// Update is called once per frame
	void Update () {
		if (Network.isServer)
		{
			newPos.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			newPos.y = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			c.Move(newPos);

			if (Vector3.Distance(transform.position, lastPosition) > minimumMovement)
			{
				lastPosition = transform.position;
				networkView.RPC("SetPosition", RPCMode.Others, transform.position);
			}


			//transform.localPosition = newPos;
		}
	}

	/*void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
			if (stream.isWriting) 
			{
					Vector3 pos = transform.localPosition;
					stream.Serialize (ref pos);
			}
			else
			{
				//Vector3 receivedPosition = transform.position;
				Vector3 receivedPosition = Vector3.zero;
				stream.Serialize(ref receivedPosition);
				transform.position = receivedPosition;
			}
	}*/

	[RPC]
	void SetPosition(Vector3 newPosition)
	{
		transform.position = newPosition;
	}


	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Disconnected");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect"))
			{
				Network.Connect(connectionIP, connectionPort);
			}
			if (GUI.Button(new Rect(10, 50, 120, 20), "Initialize Server"))
			{
				Network.InitializeServer(32, connectionPort, false);
			}
		}
		else if (Network.peerType == NetworkPeerType.Client)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);
			}
		}
		else if (Network.peerType == NetworkPeerType.Server)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Server");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);
			}
		}
	}
}
