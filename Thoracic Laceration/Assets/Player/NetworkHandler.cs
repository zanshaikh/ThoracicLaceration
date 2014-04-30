using UnityEngine;
using System.Collections;

using System.Net;

public class NetworkHandler : MonoBehaviour {
	string serverIP;
	string connectionIP = "0.0.0.0";
	public string localhostIP = "127.0.0.1"; //for testing purposes
	public int connectionPort = 25001;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);	//when loading other levels, doesn't destroy the network object
		
		string host = Dns.GetHostName();
		IPHostEntry ip = Dns.GetHostEntry(host);	//grabs all the ip entries for this computer
		serverIP = ip.AddressList[0].ToString();	//converts frist ip address in list to string
	}
	
	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Disconnected){
			GUI.Label(new Rect(10, 10, 200, 20), "Status: Disconnected");
			
			if (GUI.Button(new Rect(10, 30, 120, 20), "Play Tutorial")){
				Network.InitializeServer(0, connectionPort, false);  //the first parameter is zero so that no one can connect
				Application.LoadLevel(1);
			}
			
			if (GUI.Button(new Rect(10, 50, 120, 20), "Create Server")){
				Network.InitializeServer(32, connectionPort, false);
				Application.LoadLevel(2);
			}
			
			connectionIP = GUI.TextField(new Rect(10, 80, 120, 20), connectionIP);
			
			if (GUI.Button(new Rect(10, 100, 120, 20), "Client Connect")){
				Network.Connect(serverIP, connectionPort); //change serverIP to localhostIP for testing on same computer
				Application.LoadLevel(2);
			}
		}
		else if (Network.peerType == NetworkPeerType.Client){
			GUI.Label(new Rect(10, 10, 300, 20), "Connected as Client");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
				Network.Disconnect(200);
			}
		}
		else{
			GUI.Label(new Rect(10, 10, 300, 20), "Server IP:" + serverIP);
			if (GUI.Button(new Rect(10, 30, 120, 20), "Shutdown Server")){
				Network.Disconnect(200);
			}
		}
	}
}
