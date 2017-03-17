using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    void Awake() {
        Application.targetFrameRate = 30;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Variables.delta_t = Time.deltaTime;
	}
}
