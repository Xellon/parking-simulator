using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorial_90deg : MonoBehaviour {

   // public Transform car;
    private Movement_v2 script; //Car movement script
    private Transform car;
    public GameObject ui;

    private Vector3 car_position;
    private Quaternion car_rotation;

    private bool start=true;
    public float rotation_time = 6.0f;
    public float drive_time = 2.0f;
    public float pause_time = 3.0f;

    // Use this for initialization
    void Start () {
        car = GameObject.FindGameObjectWithTag("PlayerCar").transform;
        script = car.GetComponent<Movement_v2>();
        car_position = car.position;
        car_rotation = car.rotation;

    }
	
	// Update is called once per frame
	void Update () {
        if (start) {
            StartCoroutine("tutorial");
            start = false;
        }
	}

    IEnumerator tutorial() {
        float time;
        Text comment = ui.transform.FindChild("InstructionPanel").transform.FindChild("Comment").GetComponent<Text>();
        script.setSimulate(true); // Movement scripte ijungia simulation rezima, t.y. zmogus nk negali daryt ir yra simuliuojamas input


        comment.text = "Privaziuokite 1m atstumu nuo masinu taip, kad jusu veidrodeliai sutaptu su antro automobilio desiniuoju krastu, o jusu masinos kampas butu 90 laipsniu";
        yield return new WaitForSeconds(pause_time);

        comment.text = "Susireguliuokite veidrodelius, kad matytumete linijas; Dabar jie uz jus jau yra sureguliuoti";
        yield return new WaitForSeconds(pause_time);

        time = 0.0f;
        comment.text = "Pasukite vaira kiek galite i desine";
        while (time < rotation_time) {
            script.setHorizontalAxis(1);
            time += Time.deltaTime;
            yield return null;
        }
        script.setHorizontalAxis(1);

        //Galima butu tiesiogiai, jei taip paprasciau riboti greiti per Variables.speed; Taip pat ir vairo apsisukima
        time = 0.0f;
        comment.text = "Vaziuokite, kol masina neissitiesins";
        while (time < drive_time) {
            script.setVerticalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0.0f;
        comment.text = "Issukite vaira, uzreaukite stabdi";
        while (time < rotation_time) {
            script.setHorizontalAxis(-1);
            time += Time.deltaTime;
            yield return null;
        }

        script.setSimulate(false);
        car.position = car_position;
        car.rotation = car_rotation;
        ui.transform.FindChild("InstructionPanel").gameObject.SetActive(false);
        ui.transform.FindChild("Task").gameObject.SetActive(true);
        yield return null;
    }
}
