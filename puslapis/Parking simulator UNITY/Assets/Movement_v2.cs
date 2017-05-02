using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_v2 : MonoBehaviour
{
    private GameObject masina;
    private GameObject vairas;
    private WheelCollider[] wheel_colliders = new WheelCollider[4];
    private Transform[] wheel = new Transform[4];

    [Range (1f,900f)]
    public float stabdziu_galia;
    [Range(1, 60)]
    public int sukimo_kampas;

    private string mode = "Arcade";

    //Sounds
    public AudioClip garsas_uzvedimo;
    public AudioClip garsas_vaziavimo;
    public AudioClip garsas_stabdymo;
    public AudioClip garsas_atsitrenkimo;
    private AudioClip currentPlay;
    private AudioSource audio;
    private float volume;

    //**************************************************************************************************************************************************************

    void Start() {
        vairas = GameObject.Find("Vairas");

        //Ratu nustatymai
        masina = GameObject.FindGameObjectWithTag("PlayerCar");
        wheel_colliders[0] = GameObject.Find("RRcol").GetComponent<WheelCollider>();
        wheel_colliders[1] = GameObject.Find("RLcol").GetComponent<WheelCollider>();
        wheel_colliders[2] = GameObject.Find("FRcol").GetComponent<WheelCollider>();
        wheel_colliders[3] = GameObject.Find("FLcol").GetComponent<WheelCollider>();
        
        wheel[0] = masina.transform.FindChild("RatasRR");
        wheel[1] = masina.transform.FindChild("RatasRL");
        wheel[2] = masina.transform.FindChild("RatasFR");
        wheel[3] = masina.transform.FindChild("RatasFL");

        wheel_colliders[2].motorTorque = 0;
        wheel_colliders[3].motorTorque = 0;

        //Garso nustatymai
        audio = GetComponent<AudioSource>();
        volume = 0.1f;
        audio.PlayOneShot(garsas_uzvedimo, volume);
        currentPlay = garsas_uzvedimo;
    }

    //**************************************************************************************************************************************************************
    void Update() {
        Variables.speed = GetComponent<Rigidbody>().velocity.magnitude*3.6f;
        if (Input.GetButtonDown("ChangeMode")) {
            if (mode == "Precision")
                mode = "Arcade";
            else if (mode == "Arcade")
                mode = "Precision";
        }

        if (!audio.isPlaying && currentPlay != garsas_atsitrenkimo) {
            audio.PlayOneShot(garsas_vaziavimo, volume);
            currentPlay = garsas_vaziavimo;
        }
        if (currentPlay == garsas_stabdymo && Variables.speed < 1f)   {
            audio.PlayOneShot(garsas_vaziavimo, volume);
            currentPlay = garsas_vaziavimo;
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
            if (Mathf.Abs(Variables.steering_wheel) < 0.2f && Input.GetAxis("Horizontal") != 0)
                vairoSukimas();
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
                wheel_colliders[i].motorTorque -= 3*Input.GetAxis("Vertical") + Input.GetAxis("Vertical") * Variables.acceleration * Variables.delta_t;
            }
            else if (Input.GetAxis("Vertical") == 0) {
                    wheel_colliders[i].motorTorque = 0;
                    wheel_colliders[i].brakeTorque = stabdziu_galia;
              }
            else {
                wheel_colliders[i].motorTorque = 0;
                wheel_colliders[i].brakeTorque = 0;
            }
            if (Input.GetButton("Break")) {
                if (Variables.speed > 1f) {
                    audio.PlayOneShot(garsas_stabdymo, volume);
                    currentPlay = garsas_stabdymo;
                }
                ratuStabdymas();
            }
            else
                for (int q = 2; q < 4; q++)
                    wheel_colliders[q].brakeTorque = 0;
            
        }
        ratuSukimasis();
    }

    //**************************************************************************************************************************************************************

    void ratuStabdymas() {
        for (int q = 0; q < 4; q++) {
            wheel_colliders[q].motorTorque = 0;
            wheel_colliders[q].brakeTorque = stabdziu_galia * 4f;
        }
    }

    //**************************************************************************************************************************************************************

    void ratuSukimasis() {
        for (int q = 0; q < 4; q++) {
            Quaternion quater;
            Vector3 vieta;
            wheel_colliders[q].GetWorldPose(out vieta, out quater);
            wheel[q].position = vieta;
            wheel[q].rotation = quater;
        }
    }

    //**************************************************************************************************************************************************************

    void OnCollisionEnter(Collision collision) {
        audio.PlayOneShot(garsas_atsitrenkimo, volume);

    }

    //**************************************************************************************************************************************************************

    void vairoSukimas() {
        float x = Variables.delta_t / 0.0167f;
        if (Mathf.Abs(Variables.steering_wheel) != 0.2f)
                 vairas.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Variables.steering_speed *60f * x);
    }

}