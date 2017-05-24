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
    public float rotation_time = 2.0f;
    public float drive_time1 = 9.3f;
    public float drive_time2 = 4.5f;
    public float drive_time3 = 4.5f;
    public float drive_time4 = 0.6f;
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
        if (Input.GetKeyDown(KeyCode.O)) {
            StopCoroutine("tutorial");
            script.setSimulate(false);
            car.position = car_position;
            car.rotation = car_rotation;
            ui.transform.FindChild("TutorialInstructions").gameObject.SetActive(false);
            ui.transform.FindChild("TutorialInfo").gameObject.SetActive(true);
        }
    }

    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(pause_time);
        //ui.transform.FindChild("TutorialInfo").gameObject.SetActive(false);

        float time;
        Text comment = ui.transform.FindChild("TutorialInstructions").transform.FindChild("Comment").GetComponent<Text>();
        script.setSimulate(true); // Movement scripte ijungia simulation rezima, t.y. zmogus nk negali daryt ir yra simuliuojamas input

        comment.text = "Privažiuokite 1m atstumu nuo mašinų taip, kad jūsų galas sutaptų su šone esančio automobilio galu";
        yield return new WaitForSeconds(pause_time);
        time = 0.0f;
        while (time < drive_time1)
        {
            if(Variables.speed<5)
                script.setVerticalAxis(1);
            else
                script.setVerticalAxis(0);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);

        time = 0.0f;
        comment.text = "Pasukite vairą kiek galite i kairę";
        
        while (time < rotation_time)
        {
            script.setHorizontalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);


        time = 0.0f;
        comment.text = "Važiuokite, kol šone esančios mašinos galas nesutaps su jūsų automobilio viduriu";
        while (time < drive_time2)
        {
            if (Variables.speed < 3)
                script.setVerticalAxis(-1);
            else
                script.setVerticalAxis(0);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time);

        time = 0.0f;
        comment.text = "Pasukite vairą kiek galite į dešinę pusę";
        while (time < rotation_time*2f)
        {
            script.setHorizontalAxis(1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(1);
        yield return new WaitForSeconds(1);

        time = 0.0f;
        comment.text = "Važiuokite, kol jūsų automobilis bus horizontalus su tiesiai esančiu automobiliu";
        while (time < drive_time3)
        {
            if (Variables.speed < 3)
                script.setVerticalAxis(-1);
            else
                script.setVerticalAxis(0);
            time += Time.deltaTime;
            yield return null;
        }
        script.setVerticalAxis(0);
        yield return new WaitForSeconds(pause_time);

        time = 0.0f;
        comment.text = "Prireikus, galite pasukti ratus į dešinę ir pavažiuoti į priekį, kad ištiesintumėte automobilį";

        while (time < rotation_time)
        {
            script.setHorizontalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(0);
        Variables.steering_wheel = 0;

        time = 0.0f;
        while (time < drive_time4)
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
        ui.transform.FindChild("TutorialInstructions").gameObject.SetActive(false);
        ui.transform.FindChild("TutorialInfo").gameObject.SetActive(true);
        yield return null;
    }
}
