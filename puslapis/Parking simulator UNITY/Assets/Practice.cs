using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Practice : MonoBehaviour {

    public Transform player;

    public delegate void kazkas();

    public static event kazkas finished_looking;
    public static event kazkas finished_moving;
    public static event kazkas finished_braking;
    public static event kazkas finished_mode_change;

    // Use this for initialization
    void Start () {
        gameObject.transform.FindChild("IntroWindow").gameObject.SetActive(true);
        gameObject.transform.FindChild("Instructions").gameObject.SetActive(false);

        gameObject.transform.FindChild("TextInstructionsMove").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsBrake").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsLook").gameObject.SetActive(false);
        gameObject.transform.FindChild("TextInstructionsOtherMode").gameObject.SetActive(false);

        Cursor.visible = true;
        player.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void beginPractice(bool with_tutorial = false) {
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = false;
        gameObject.transform.FindChild("IntroWindow").gameObject.SetActive(false);
        Cursor.visible = false;
        if (with_tutorial)
            beginTutorial();
        else
            gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
    }

    public void beginTutorial() {
        gameObject.transform.FindChild("TextInstructionsMove").gameObject.SetActive(true);
    
   // if()

        //gameObject.transform.FindChild("Instructions").gameObject.SetActive(true);
    }

    public void checkForMoving() {
        bool v = false;
        bool h = true;

        if (Input.GetAxis("Horizontal") != 0)
            v = true;
        if (Input.GetAxis("Vertical") != 0)
            v = true;

        if(v && h) {

        }
    }

}
