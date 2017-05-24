using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Practice : MonoBehaviour {

    private Transform player;

    private delegate bool actionCheck();
    private actionCheck[] tutorialCheck = new actionCheck[4];

    private delegate void tutorialFunction();
    private tutorialFunction[] tutorialDo = new tutorialFunction[4];

    private short stage = 0; //Stage of tutorial

    //For movement checks
    private bool v = false;
    private bool h = false;
    //For looking checks
    private float delta_x = 0.0f;
    private float delta_y = 0.0f;


    private bool with_tutorial;

    //**************************************************************************************************************************************************************

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gameObject.transform.FindChild("IntroWindow").gameObject.SetActive(true);
        gameObject.transform.FindChild("Instructions").gameObject.SetActive(false);

        gameObject.transform.FindChild("TextInstructionsMove").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsBrake").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsLook").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsOtherMode").gameObject.SetActive(false);
<<<<<<< HEAD
<<<<<<< HEAD
=======
        gameObject.transform.FindChild("TextAnnouncement").gameObject.SetActive(false);
>>>>>>> develop
=======
>>>>>>> origin/julian

        //Function pointers
        tutorialCheck[0] = checkForLooking;
        tutorialCheck[1] = checkForMoving;
        tutorialCheck[2] = checkForStopping;
        tutorialCheck[3] = null;

        tutorialDo[0] = tutorialForLooking;
        tutorialDo[1] = tutorialForMoving;
        tutorialDo[2] = tutorialForBraking;
        tutorialDo[3] = tutorialFinish;

        //Letting chose an answer
        Cursor.visible = true;
        player.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
    }

    //**************************************************************************************************************************************************************

    void Update () {

        if (with_tutorial) {
            if (tutorialCheck[stage]()) {
                tutorialDo[stage + 1]();
                stage++;
            }
        }
	}

    //**************************************************************************************************************************************************************

    public void beginPractice(bool with_tutorial = false) {
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        gameObject.transform.FindChild("IntroWindow").gameObject.SetActive(false);
        Cursor.visible = false;
        if (with_tutorial) {
            tutorialDo[0]();
            this.with_tutorial = true;
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        else
            gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
=======
        else {
            gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
            gameObject.transform.FindChild("TextAnnouncement").gameObject.SetActive(true);
        }
>>>>>>> develop
=======
        else
            gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
>>>>>>> origin/julian
=======
        else {
            gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
        }
>>>>>>> develop
    }

    //**************************************************************************************************************************************************************

    public void tutorialForLooking() {
        gameObject.transform.FindChild("TextInstructionsLook").gameObject.SetActive(true);
    }

    //**************************************************************************************************************************************************************

    public void tutorialForMoving() {
        gameObject.transform.FindChild("TextInstructionsLook").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsMove").gameObject.SetActive(true);
    }

    //**************************************************************************************************************************************************************

    public void tutorialForBraking() {
        gameObject.transform.FindChild("TextInstructionsMove").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsBrake").gameObject.SetActive(true);
    }

    //**************************************************************************************************************************************************************

    public void tutorialFinish() {
        gameObject.transform.FindChild("TextInstructionsBrake").gameObject.SetActive(false);
        gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        gameObject.transform.FindChild("TextAnnouncement").gameObject.SetActive(true);
>>>>>>> develop
=======
>>>>>>> origin/julian
=======
        with_tutorial = false;
>>>>>>> develop
    }

    //**************************************************************************************************************************************************************

    public bool checkForMoving() {
        if (Input.GetAxis("Horizontal") != 0)
            h = true;
        if (Input.GetAxis("Vertical") != 0)
            v = true;

        if(v && h)
            return true;
        return false;
    }

    //**************************************************************************************************************************************************************

    public bool checkForLooking() {
        delta_x += Mathf.Abs(Input.GetAxis("Mouse X"));
        delta_y += Mathf.Abs(Input.GetAxis("Mouse Y"));

        if (delta_x > 100 && delta_y >50)
            return true;
        return false;
    }

    //**************************************************************************************************************************************************************

    public bool checkForStopping() {
        if (Variables.speed != 0 && Input.GetAxis("Break") != 0)
            return true;
        return false;
    }

    //**************************************************************************************************************************************************************

}
