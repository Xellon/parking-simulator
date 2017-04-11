using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public Canvas main_menu;
    public Canvas settings_menu;
    public Canvas about_menu;
    public Canvas score_menu;

	// Use this for initialization
	void Start () {
        main_menu = main_menu.GetComponent<Canvas>();
        settings_menu= settings_menu.GetComponent<Canvas>();
        about_menu = about_menu.GetComponent<Canvas>();
        score_menu = score_menu.GetComponent<Canvas>();

        settings_menu.enabled = false;
        score_menu.enabled = false;
        about_menu.enabled = false;

        main_menu.enabled = true;

    }
	
    public void scorePress() {
        score_menu.enabled = true;

        main_menu.enabled = false;
        settings_menu.enabled = false;
        about_menu.enabled = false;
    }

    public void settingsPress() {
        score_menu.enabled = false;
        main_menu.enabled = false;
        about_menu.enabled = false;

        settings_menu.enabled = true;
    }

    public void aboutPress() {
        score_menu.enabled = false;
        main_menu.enabled = false;
        settings_menu.enabled = false;

        about_menu.enabled = true;
    }

    /*public void playPress() {

    }*/

    public void backPress() {
        settings_menu.enabled = false;
        score_menu.enabled = false;
        about_menu.enabled = false;

        main_menu.enabled = true;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
