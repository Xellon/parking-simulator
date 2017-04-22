using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_v2 : MonoBehaviour
{

    public WheelCollider[] wheel_colliders = new WheelCollider[4];
    public Transform[] wheel = new Transform[4];
    [Range (1f,900f)]
    public float stabdziu_galia;
    [Range(1, 60)]
    public int sukimo_kampas;
    private string mode = "Arcade";    

    //**************************************************************************************************************************************************************
    void Update() {
        Variables.speed = GetComponent<Rigidbody>().velocity.magnitude*3.6f;
        if (Input.GetButtonDown("ChangeMode")) {
            if (mode == "Precision")
                mode = "Arcade";
            else if (mode == "Arcade")
                mode = "Precision";
        }

       ratuJudejimas();
   
        float rotation_speed = 0;
        if (mode == "Precision") {
            Variables.steering_wheel += Input.GetAxis("Horizontal") * Variables.steering_speed * Variables.delta_t;
            if (Variables.steering_wheel > 0.2f)
                Variables.steering_wheel = 0.2f;
            else if (Variables.steering_wheel < -0.2f)
                Variables.steering_wheel = -0.2f;

            wheel_colliders[3].steerAngle = sukimo_kampas * 5 * Variables.steering_wheel;
            wheel_colliders[2].steerAngle = sukimo_kampas * 5 * Variables.steering_wheel;
        }
        else if (mode == "Arcade") {
            rotation_speed = Input.GetAxis("Horizontal") * Variables.steering_speed * (Variables.speed <= 6.0f ? Variables.speed : 6.0f);
            Variables.steering_wheel = rotation_speed;
            wheel_colliders[3].steerAngle = sukimo_kampas * Variables.steering_wheel*1.66f;
            wheel_colliders[2].steerAngle = sukimo_kampas * Variables.steering_wheel*1.66f;
        }   
    }
   
    //**************************************************************************************************************************************************************

    void ratuJudejimas() {
        for (int i = 0; i < 2; i++) {
            if (Variables.speed < Variables.max_speed && Input.GetAxis("Vertical") != 0) {
                wheel_colliders[i].brakeTorque = 0;
                if (Mathf.Abs(wheel_colliders[i].motorTorque) > 200)
                    wheel_colliders[i].motorTorque = -200 * Input.GetAxis("Vertical");
                wheel_colliders[i].motorTorque -= 3+Input.GetAxis("Vertical") * Variables.acceleration * Variables.delta_t;
            }
            else if (Input.GetAxis("Vertical") == 0) {
                    wheel_colliders[i].motorTorque = 0;
                    wheel_colliders[i].brakeTorque = stabdziu_galia;
              }
            else {
                wheel_colliders[i].motorTorque = 0;
                wheel_colliders[i].brakeTorque = 0;
            }
  
            if (Input.GetButton("Break"))
                ratuStabdymas();
            else
                for (int q = 2; q < 4; q++)
                    wheel_colliders[q].brakeTorque = 0;
        }
        ratuSukimasis();
    }

    void ratuStabdymas() {
        for (int q = 0; q < 4; q++) {
            wheel_colliders[q].motorTorque = 0;
            wheel_colliders[q].brakeTorque = stabdziu_galia * 4f;
        }
    }

    void ratuSukimasis() {
        for (int q = 0; q < 4; q++) {
            Quaternion quater;
            Vector3 vieta;
            wheel_colliders[q].GetWorldPose(out vieta, out quater);
            wheel[q].position = vieta;
            wheel[q].rotation = quater;
        }
    }
}