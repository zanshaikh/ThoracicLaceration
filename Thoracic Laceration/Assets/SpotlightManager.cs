using UnityEngine;
using System.Collections;

public class SpotlightManager : MonoBehaviour {
	public Vector3 movementValue; 
	public Vector3 placeHold; 
	float spacer = 0;
	bool hasRun;



	// Use this for initialization
	void Start () {
		movementValue.y = 0f;
		movementValue.x = transform.localPosition.x;
		movementValue.z = 0f;
		placeHold.y = transform.localPosition.y;
		placeHold.x = transform.localPosition.x;
		placeHold.z = transform.localPosition.z;
		StartCoroutine (WaitRotate ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator WaitRotate(){
		while (true) {
			hasRun = false;
			while ((spacer < 32) && hasRun == false) {
				movementValue.x = 0.625f;
				spacer++;
				print (spacer);
				transform.Translate (movementValue);		
				yield return new WaitForSeconds (0.025f);
			}
			hasRun = true;
			yield return new WaitForSeconds (1f);
			while ((spacer > -32) && hasRun == true) {
				movementValue.x = -0.625f;
				spacer--;
				print (spacer);
				transform.Translate (movementValue);		
				yield return new WaitForSeconds (0.025f);
			}
			yield return new WaitForSeconds (1f);
						
		}

	}
}
