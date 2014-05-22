using UnityEngine;
using System.Collections;

public class SpotlightManager : MonoBehaviour {
	public Vector3 movementValue; 
	float spacer = 0;
	public float howFar = 0.625f;
	bool hasRun;



	// Use this for initialization
	void Start () {
		movementValue.y = transform.localPosition.y;
		movementValue.x = 0f;
		movementValue.z = 0f;
		StartCoroutine (WaitRotate ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator WaitRotate(){
		while (true) {
			hasRun = false;
			while ((spacer < 32) && hasRun == false) {
				movementValue.y = howFar;
				spacer++;
				transform.Translate (movementValue);		
				yield return new WaitForSeconds (0.025f);
			}
			hasRun = true;
			yield return new WaitForSeconds (1f);
			while ((spacer > -32) && hasRun == true) {
				movementValue.y = -howFar;
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
