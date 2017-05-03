using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parking : MonoBehaviour {
    public GameObject masina;
    private GameObject park;

    void Start() {
        park = gameObject;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && Variables.speed < 0.01 && Variables.speed > -0.01)
            parkCheck();
    }
    private void parkCheck () {
        Debug.Log(park.transform.position.x + " and " + masina.transform.position.x);
        if ((park.transform.position.x <= masina.transform.position.x + 0.3) && (park.transform.position.x >= masina.transform.position.x - 0.3) && 
            (park.transform.position.z <= masina.transform.position.z + 0.2) && (park.transform.position.z >= masina.transform.position.z - 0.2) &&
            (masina.transform.rotation.y == park.transform.rotation.y)  )
                Debug.Log("Parked");
        else
                Debug.Log("Failed");
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Kliutis1" || collision.gameObject.name == "Kliutis2")
            SceneManager.LoadScene("test platform", LoadSceneMode.Single);
    }
}
