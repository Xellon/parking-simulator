using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private GameObject car;

    private float delta_hold = 0.0f;
    private string mode = "Arcade";

    //**************************************************************************************************************************************************************

    void Start () {
        car = gameObject;
    }

    //**************************************************************************************************************************************************************

    void Update () {
        if (Input.anyKeyDown) {
            delta_hold = 0;
        }
        else {
            delta_hold += Variables.delta_t;
            if (delta_hold > 100)
                delta_hold = 100;
        }
        if (Input.GetButtonDown("ChangeMode")) {
            if (mode == "Precision")
                mode = "Arcade";
            else if (mode == "Arcade")
                mode = "Precision";
        }

        Variables.speed -= Input.GetAxis("Vertical") * Variables.acceleration * Variables.delta_t;

        float rotation_speed=0;
        if (mode == "Precision") {
            Variables.steering_wheel += Input.GetAxis("Horizontal") * Variables.steering_speed * Variables.delta_t;
            if (Variables.steering_wheel > 0.2f)
                Variables.steering_wheel = 0.2f;
            else if (Variables.steering_wheel < -0.2f)
                Variables.steering_wheel = -0.2f;

            rotation_speed = -Variables.steering_wheel * (Variables.speed <= 1.0f ? Variables.speed : 1.0f);
            if (Variables.steering_wheel > 0)
                car.transform.RotateAround(car.transform.FindChild("RatasRL").position, Vector3.up, rotation_speed);
            if (Variables.steering_wheel < 0)
                car.transform.RotateAround(car.transform.FindChild("RatasRR").position, Vector3.up, rotation_speed);
        }
        else if (mode == "Arcade") {
            rotation_speed = Input.GetAxis("Horizontal") * Variables.steering_speed  * (Variables.speed <= 1.0f ? Variables.speed : 1.0f);
            Variables.steering_wheel = -rotation_speed;
            if (rotation_speed > 0)
                car.transform.RotateAround(car.transform.FindChild("RatasRL").position, Vector3.up, -rotation_speed);
            if (rotation_speed < 0)
                car.transform.RotateAround(car.transform.FindChild("RatasRR").position, Vector3.up, -rotation_speed);
        }

        car.transform.Translate(Vector3.forward * Variables.speed * Time.deltaTime);

        if (Input.GetButton("Break")) {
            slowDown(Variables.brakes);
        }
        if (delta_hold > 0.5) {
            slowDown(Variables.deacceleration);
        }

    }

    //**************************************************************************************************************************************************************

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

    //**************************************************************************************************************************************************************

}
