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
    private bool parked = false;

    //Sounds
    private AudioClip garsas_uzvedimo;
    private AudioClip garsas_vaziavimo;
    private AudioClip garsas_stabdymo;
    private AudioClip garsas_atsitrenkimo;
    private AudioClip garsas_parked;
    private AudioClip garsas_failed;
    private AudioClip currentPlay;
    private AudioSource audios;
    public static float volume;

    private bool simulate = false;
    private float vertical_axis;
    private float horizontal_axis;

    private float timer = 0f;
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
        garsas_uzvedimo = Resources.Load<AudioClip>("Sounds/carStart");
        garsas_vaziavimo = Resources.Load<AudioClip>("Sounds/carEngine");
        garsas_stabdymo = Resources.Load<AudioClip>("Sounds/carBrakes");
        garsas_atsitrenkimo = Resources.Load<AudioClip>("Sounds/carCrash");
        garsas_parked = Resources.Load<AudioClip>("Sounds/carParked");
        garsas_failed = Resources.Load<AudioClip>("Sounds/carFailed");

        audios = GetComponent<AudioSource>();
        volume = 0.1f;
        audios.PlayOneShot(garsas_uzvedimo, volume);
        currentPlay = garsas_uzvedimo;
    }

    //**************************************************************************************************************************************************************
    void Update() {
        Variables.speed = GetComponent<Rigidbody>().velocity.magnitude*3.6f;
        if (!simulate) {
            setHorizontalAxis();
            setVerticalAxis();
        }
        if (Input.GetButtonDown("ChangeMode")) {
            if (mode == "Precision")
                mode = "Arcade";
            else if (mode == "Arcade")
                mode = "Precision";
        }
        if (!audios.isPlaying && currentPlay != garsas_atsitrenkimo && currentPlay != garsas_parked) {
            audios.Stop();
            audios.PlayOneShot(garsas_vaziavimo, volume);
            currentPlay = garsas_vaziavimo;
        }
        if (currentPlay == garsas_stabdymo && Variables.speed < 2f)   {
            audios.Stop();
            audios.PlayOneShot(garsas_vaziavimo, volume);
            currentPlay = garsas_vaziavimo;
        }
        if (audios.isPlaying && currentPlay == garsas_vaziavimo)
            audios.pitch = 1 + Mathf.Abs(vertical_axis *0.2f) ;
        ratuJudejimas();
   
        float rotation_speed = 0;
        if (mode == "Precision") {
            Variables.steering_wheel += horizontal_axis * Variables.steering_speed * Variables.delta_t;
            if (Variables.steering_wheel > 0.2f)
                Variables.steering_wheel = 0.2f;
            else if (Variables.steering_wheel < -0.2f)
                Variables.steering_wheel = -0.2f;
            
            wheel_colliders[3].steerAngle = sukimo_kampas * 5 * Variables.steering_wheel;
            wheel_colliders[2].steerAngle = sukimo_kampas * 5 * Variables.steering_wheel;
            if (Mathf.Abs(Variables.steering_wheel) < 0.2f && horizontal_axis != 0)
                vairoSukimas();
        }
        else if (mode == "Arcade") {
            rotation_speed = horizontal_axis * Variables.steering_speed * (Variables.speed <= 6.0f ? Variables.speed : 6.0f);
            Variables.steering_wheel = rotation_speed;
            wheel_colliders[3].steerAngle = sukimo_kampas * Variables.steering_wheel*1.66f;
            wheel_colliders[2].steerAngle = sukimo_kampas * Variables.steering_wheel*1.66f;
        }

        if (Variables.speed < 0.001 && horizontal_axis == 0 && vertical_axis == 0 && !simulate)
            timer += Time.deltaTime;
        else
            timer = 0f;
        if (timer > 1f)
            parkingCheck();
    }
    //**************************************************************************************************************************************************************

    void parkingCheck() {
        int level_id;

        if (ParkingTrigger.trigger1 && ParkingTrigger.trigger2 && ParkingTrigger.trigger3 &&
            ParkingTrigger.trigger4 && ParkingTrigger.trigger5 && ParkingTrigger.trigger6 &&
            Variables.speed < 0.1)
        {
            if (currentPlay != garsas_parked)
                audios.Stop();
            if (!audios.isPlaying && !simulate && currentPlay != garsas_parked)  {
                currentPlay = garsas_parked;
                audios.PlayOneShot(garsas_parked, volume * 5);
            }
            else if (!audios.isPlaying && !simulate) {
                level_id = Variables.current_level + 1;
                if (level_id == 7)
                    level_id = 0;
                Debug.Log(level_id);
                LevelChoice.startLevel(level_id);
            }
        }
    }

    //**************************************************************************************************************************************************************

    void ratuJudejimas() {
        for (int i = 0; i < 2; i++) {
            if (Variables.speed < Variables.max_speed && vertical_axis != 0) {
                wheel_colliders[i].brakeTorque = 0;
                if (Mathf.Abs(wheel_colliders[i].motorTorque) > 200)
                    wheel_colliders[i].motorTorque = -200 * vertical_axis;
                wheel_colliders[i].motorTorque -= 3 * vertical_axis + vertical_axis * Variables.acceleration * Variables.delta_t;
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
                    audios.PlayOneShot(garsas_stabdymo, volume);
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
    //Tam, kad galima butu simuliuot judejima tutorialuose
    public void setSimulate(bool choice) {
        simulate = choice;
        if(choice)
            mode = "Precision";
        else
            mode = "Arcade";
    }

    //**************************************************************************************************************************************************************

    public void setHorizontalAxis(float amount = 0) {
        if (!simulate)
            horizontal_axis = Input.GetAxis("Horizontal");
        else
            horizontal_axis = amount;

    }

    //**************************************************************************************************************************************************************

    public void setVerticalAxis(float amount = 0) {
        if (!simulate)
            vertical_axis = Input.GetAxis("Vertical");
        else
            vertical_axis = amount;
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

    public bool getParked()
    {
        return parked;
    }

    //**************************************************************************************************************************************************************

    void OnCollisionEnter(Collision collision) {
        if (!simulate)
        audios.PlayOneShot(garsas_atsitrenkimo, volume*3);
       

    }

    //**************************************************************************************************************************************************************

    void vairoSukimas() {
        float x = Variables.delta_t / 0.0167f;
        if (Mathf.Abs(Variables.steering_wheel) != 0.2f)
                 vairas.transform.Rotate(Vector3.up * horizontal_axis * Variables.steering_speed *60f * x);
    }

}