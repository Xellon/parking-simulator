using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scenario:
// (x) Load scene with camera from above (90 degrees?)
// (x) Show a description of the tutorial + objectives and loop animation
// (x) After you're done looking at animation press button to play
// (x) Replay animation from the menu
// ( ) Win condition when in collision box

public class Tutorial1 : MonoBehaviour {

	public Transform vehicle;

	private Transform player;

    private Vector3 initialPos;
    private Quaternion initialRot;

	void Start () {
		player = vehicle.gameObject.transform.Find("FPSController");

        initialPos = vehicle.position;
        initialRot = vehicle.rotation;

        vehicle.GetComponent<Animation>().Play();
    }

	void Update () {
		if (Input.anyKey)
		{
			player.gameObject.SetActive(true);

			vehicle.GetComponent<Animation>().Stop();

            vehicle.position = initialPos;
            vehicle.rotation = initialRot;

            this.gameObject.SetActive(false);
		}
		
	}
}
