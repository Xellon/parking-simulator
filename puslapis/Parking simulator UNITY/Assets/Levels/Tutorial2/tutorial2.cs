using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial2 : MonoBehaviour {
    // public Transform car;
    private Movement_v2 script; //Car movement script
    private Transform car;
    public GameObject ui;

    private Vector3 car_position;
    private Quaternion car_rotation;

    private bool start = true;
    public float rotation_time = 6.0f;
    public float drive_time = 2.0f;
    public float pause_time = 3.0f;

    // Use this for initialization
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("PlayerCar").transform;
        script = car.GetComponent<Movement_v2>();
        car_position = car.position;
        car_rotation = car.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StartCoroutine("tutorial");
            start = false;
        }
    }

    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(pause_time);
        ui.transform.FindChild("Task").gameObject.SetActive(false);

        float time;
        Text comment = ui.transform.FindChild("InstructionPanel").transform.FindChild("Comment").GetComponent<Text>();
        script.setSimulate(true); // Movement scripte ijungia simulation rezima, t.y. zmogus nk negali daryt ir yra simuliuojamas input

        comment.text = "Privaziuokite 1m atstumu nuo masinu taip, kad jusu galas sutaptu su sone esancio automobilio galu";
        yield return new WaitForSeconds(pause_time);
        time = 0.0f;
        while (time < 3.57f)
        {
            script.setVerticalAxis(1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time*2);


        time = 0.0f;
        comment.text = "Pasukite vaira kiek galite i kaire";
        
        while (time < rotation_time)
        {
            script.setHorizontalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(-1);
        yield return new WaitForSeconds(1);

        //Galima butu tiesiogiai, jei taip paprasciau riboti greiti per Variables.speed; Taip pat ir vairo apsisukima
        time = 0.0f;
        comment.text = "Vaziuokite, kol sone esancios masinos galas nesutaps su jusu automobilio viduriu";
        while (time < 1.885f)
        {
            script.setVerticalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time);

        time = 0.0f;
        comment.text = "Pasukite vaira kiek galite i desine puse";
        while (time < rotation_time*1.5f)
        {
            script.setHorizontalAxis(1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(1);
        yield return new WaitForSeconds(1);

        time = 0.0f;
        comment.text = "Vaziuokite, kol jusu automobilis bus horizontalus su tiesiai esanciu automobiliu";
        while (time < 1.85f)
        {
            script.setVerticalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time);

        time = 0.0f;
        comment.text = "Prireikus, galite pasukti ratus i desine ir pavaziuoti i prieki, kad istiesintumete automobili";
        while (time < rotation_time*2.8f)
        {
            script.setHorizontalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(0);
        time = 0.0f;
        while (time < 1f)
        {
            script.setVerticalAxis(1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time);


        script.setSimulate(false);
        car.position = car_position;
        car.rotation = car_rotation;
        ui.transform.FindChild("InstructionPanel").gameObject.SetActive(false);
        ui.transform.FindChild("Task").gameObject.SetActive(true);
        yield return null;
    }
}
