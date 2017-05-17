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

    public Transform infoPanel;
    public Transform winPanel;

    private Vector3 initialPos;
    private Quaternion initialRot;
    private Animation tutorialCinematic;

	void Start () {
		player = vehicle.gameObject.transform.Find("FPSController");
        tutorialCinematic = vehicle.GetComponent<Animation>();

        CarUI.SetActive(false);
        player.gameObject.SetActive(false);

        infoPanel.gameObject.SetActive(true);
        winPanel.gameObject.SetActive(false);

        initialPos = vehicle.position;
        initialRot = vehicle.rotation;

        tutorialCinematic.Play();
    }

	void Update () {

        // Parodoma kaip parkuojamasi
		if (Input.anyKey && tutorialCinematic.isPlaying)
		{
			player.gameObject.SetActive(true);
            CarUI.SetActive(true);

			tutorialCinematic.Stop();

            vehicle.position = initialPos;
            vehicle.rotation = initialRot;

            infoPanel.gameObject.SetActive(false);
		}

        // 
        if (vehicle.GetComponent<Movement_v2>().getParked())
        {
            Debug.Log("Parked");
            winPanel.gameObject.SetActive(true);
        }

		
	}
}
