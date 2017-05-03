using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parking : MonoBehaviour {
    private GameObject masina;    //automobilis
    private GameObject park;      //parkavimo vieta

    // Update is called once per frame
    void Start() {
        masina = GameObject.Find("BMW X5");    
        park = GameObject.Find("parkspot");    
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Variables.speed < 0.01 && Variables.speed > -0.01)
            parkCheck();
    }
    private void parkCheck () {
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
