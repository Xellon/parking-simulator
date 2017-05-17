using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Win condition

// vehicle: visas automobilio objektas
// CarUI: FrontUI objektas

public class Tutorial1 : MonoBehaviour {

	public Transform vehicle;
    public GameObject CarUI;

	private Transform player;

    private Vector3 initialPos;
    private Quaternion initialRot;

	void Start () {
		player = vehicle.gameObject.transform.Find("FPSController");

        player.gameObject.SetActive(false);
        CarUI.SetActive(false);

        initialPos = vehicle.position;
        initialRot = vehicle.rotation;

        vehicle.GetComponent<Animation>().Play();
    }

	void Update () {
		if (Input.anyKey)
		{
			player.gameObject.SetActive(true);
            CarUI.SetActive(true);

			vehicle.GetComponent<Animation>().Stop();

            vehicle.position = initialPos;
            vehicle.rotation = initialRot;

            this.gameObject.SetActive(false);
		}
		
	}
}
