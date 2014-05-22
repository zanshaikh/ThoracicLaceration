using UnityEngine;
using System.Collections;

public class SpotlightTwo : MonoBehaviour {
	public Vector3 movementValue; 
	float spacer = 0;
	public float howFar;
	bool hasRun;
	
	
	
	// Use this for initialization
	void Start () {
		movementValue.x = transform.localPosition.y;
		movementValue.y = 0f;
		movementValue.z = 0f;
		StartCoroutine (WaitRotate ());
		howFar = 0.625f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator WaitRotate(){
		while (true) {
			hasRun = false;
			while ((spacer < 32) && hasRun == false) {
				movementValue.x = howFar;
				spacer++;
				transform.Translate (movementValue);		
				yield return new WaitForSeconds (0.025f);
			}
			hasRun = true;
			yield return new WaitForSeconds (1f);
			while ((spacer > -32) && hasRun == true) {
				movementValue.x = -howFar;
				spacer--;
				transform.Translate (movementValue);		
				yield return new WaitForSeconds (0.025f);
			}
			yield return new WaitForSeconds (1f);
			
		}
		
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
	
}