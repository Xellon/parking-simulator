using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas main_menu;
    public Canvas settings_menu;
    public Canvas score_menu;

    //**************************************************************************************************************************************************************

    void Start () {
        main_menu = main_menu.GetComponent<Canvas>();
        settings_menu= settings_menu.GetComponent<Canvas>();
        score_menu = score_menu.GetComponent<Canvas>();

        settings_menu.enabled = false;
        score_menu.enabled = false;
        main_menu.enabled = true;

    }

    //**************************************************************************************************************************************************************

    public void scorePress() {
        score_menu.enabled = true;

        main_menu.enabled = false;
        settings_menu.enabled = false;
    }

    //**************************************************************************************************************************************************************

    public void settingsPress() {
        score_menu.enabled = false;
        main_menu.enabled = false;

        settings_menu.enabled = true;
    }

    //**************************************************************************************************************************************************************

    public void continuePress() {
        SceneManager.LoadScene(Variables.level_names[Variables.starting_level], LoadSceneMode.Single);
        Variables.current_level = Variables.starting_level;
    }

    //**************************************************************************************************************************************************************

    public void chooseLevelPress() {
        SceneManager.LoadScene(Variables.level_names[1], LoadSceneMode.Single);
        Variables.current_level = 1;
    }

    //**************************************************************************************************************************************************************

    public void backPress() {
        settings_menu.enabled = false;
        score_menu.enabled = false;

        main_menu.enabled = true;
    }

    //**************************************************************************************************************************************************************

    void Update () {
		
	}

    //**************************************************************************************************************************************************************

}
