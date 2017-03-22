using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private GameObject car;

    private float delta_hold = 0.0f;

	// Use this for initialization
	void Start () {
        car = GameObject.FindGameObjectsWithTag("PlayerCar")[0];

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            delta_hold = 0;
        }
        else {
            delta_hold += Variables.delta_t;
            if (delta_hold > 100)
                delta_hold = 100;
        }

        Variables.steering_wheel += Input.GetAxis("Horizontal") * Variables.delta_steering_wheel * Variables.delta_t;
        if (Variables.steering_wheel > 0.2f)
            Variables.steering_wheel = 0.2f;
        else if (Variables.steering_wheel < -0.2f)
            Variables.steering_wheel = -0.2f;

        Variables.speed -= Input.GetAxis("Vertical") * Variables.acceleration * Variables.delta_t;

        car.transform.Translate(Vector3.forward * Variables.speed * Time.deltaTime);


        float rotation_speed = Variables.steering_wheel * (Variables.speed<=1.0f? Variables.speed:1.0f);


        if (Variables.steering_wheel > 0)
            car.transform.RotateAround(car.transform.FindChild("RearL").position, Vector3.up, -rotation_speed);
        if (Variables.steering_wheel < 0)
            car.transform.RotateAround(car.transform.FindChild("RearR").position, Vector3.up, -rotation_speed);


        if (Input.GetButton("Break")) {
            slowDown(Variables.brakes);
            Debug.Log("Breaking");
        }
        if (delta_hold > 0.5) {
            slowDown(Variables.deacceleration);
        }

        Debug.Log("Speed" + Variables.speed/ (Variables.delta_t *100));
    }

    void slowDown(float rate) {
        if (Variables.speed > 0) {
            Variables.speed -= rate * Variables.delta_t;
            if (Variables.speed < 0)
                Variables.speed = 0;
        }
        else if (Variables.speed < 0) {
            Variables.speed += rate * Variables.delta_t;
            if (Variables.speed > 0)
                Variables.speed = 0;
        }

    }
}
