using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpotGlow : MonoBehaviour {
    private Transform car;
    private Material glow;

    private float safe_zone = 20.0f;
    private float no_glow_zone = 10.0f;
    // Use this for initialization
    void Start () {
        car = GameObject.FindGameObjectWithTag("PlayerCar").transform;
        glow = GetComponent<Renderer>().material;

    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, car.position) < no_glow_zone)
            glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, 0.0f);
        else if (Vector3.Distance(transform.position, car.position) > safe_zone + no_glow_zone)
            glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, 0.5f);
        else
            glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, 0.5f * ((Vector3.Distance(transform.position, car.position)- no_glow_zone) / safe_zone));
    }
}
