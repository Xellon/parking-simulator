using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {
    public static float delta_t = 0.0f;

    public static float speed = 0.0f; //Kmph
    public static float acceleration = 3.0f; //mps^2
    public static float deacceleration = 1.0f; //mps^2
    public static float brakes = 10.0f; //mps^2
    public static float steering_wheel = 0.0f; //Kampas, if kampas < 0 - kaire, else desine
    public static float delta_steering_wheel = 0.05f;

    //Kuriose vietose yra ratai, naudojami sukimuisi aplink nurodytas asis
    public static Vector3[] local_wheel_point = new Vector3[4]; 

    public enum wheel{
        FRONT_L=0,
        FRONT_R=1,
        REAR_L=2,
        REAR_R=3
    }

	// Use this for initialization
	void Start () {
        //read car info from database
        //TODO
        GameObject car = GameObject.FindGameObjectsWithTag("PlayerCar")[0];
        local_wheel_point[(int)wheel.FRONT_L] = car.transform.FindChild("FrontL").position;
        local_wheel_point[(int)wheel.FRONT_R] = car.transform.FindChild("FrontR").position;
        local_wheel_point[(int)wheel.REAR_L] = car.transform.FindChild("RearL").position;
        local_wheel_point[(int)wheel.REAR_R] = car.transform.FindChild("RearR").position;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
