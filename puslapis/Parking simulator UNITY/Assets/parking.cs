using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parking : MonoBehaviour {
	public Transform carr;
	public Transform park;
	private GameObject car;

	private float delta_hold = 0.0f;

	// Use this for initialization
	void Start () {
		car = GameObject.FindGameObjectsWithTag ("PlayerCar") [0];
	}

	void checkParking()
	{
		if ((park.transform.position.x <= carr.transform.position.x + 1) && (park.transform.position.x >= carr.transform.position.x - 1) && (park.transform.position.z <= carr.transform.position.z + 1) && (park.transform.position.z >= carr.transform.position.z - 1))
			Debug.Log("Parked");
		else
			Debug.Log("Fail");
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "ASD")
			Application.LoadLevel(0);

		if (collision.gameObject.name == "ASDF")
			Application.LoadLevel(0);
	}
}
