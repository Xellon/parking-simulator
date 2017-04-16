using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scenario:
// (x) Load scene with camera from above (90 degrees?)
// (x) Show a description of the tutorial + objectives and loop animation
// (x) After you're done looking at animation press button to play
// ( ) Replay animation from the menu
// ( ) Win condition when in collision box

public class Tutorial1 : MonoBehaviour {

	public Transform vehicle;

	private Transform player;
	private Transform initialPosition;

	void Start () {
		player = vehicle.gameObject.transform.Find("FPSController");
	}

	void Update () {
		if (Input.anyKey)
		{
			vehicle.gameObject.SetActive(true);

			vehicle.Translate(initialPosition.position);
			//vehicle.Rotate(initialPosition.rotation);

			vehicle.GetComponent<Animation>().Stop();

			this.gameObject.SetActive(false);
		}
		
	}
}
