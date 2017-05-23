using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {
    public static float delta_t = 0.0f;

    public static float speed = 0.0f; //mps
    public static float max_speed = 50.0f; //mps
    public static float acceleration = 20.0f; //mps^2
    public static float deacceleration = 1.0f; //mps^2
    public static float brakes = 70.0f; //mps^2
    public static float steering_wheel = 0.0f; //Kampas, if kampas < 0 - kaire, else desine
    public static float steering_speed = 0.1f;

    public static int current_level = 0;
    public static int starting_level = 3; //Tutorial level
    public static string[] level_names = new string[100];
    //public enum wheel{
    //    FRONT_L=0,
    //    FRONT_R=1,
    //    REAR_L=2,
    //    REAR_R=3
    //}

    //**************************************************************************************************************************************************************

    void Awake () {
        level_names[0] = "MainMenu";
        level_names[1] = "LevelChoices";
        level_names[2] = "LoadingScreen";
        level_names[3] = "Intro";
        level_names[4] = "Tutorial1";
        level_names[5] = "Tutorial2";
    }

    //**************************************************************************************************************************************************************

    void Update () {

    }

    //**************************************************************************************************************************************************************

}
