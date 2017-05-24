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
<<<<<<< HEAD
<<<<<<< HEAD

=======
        Cursor.visible = true;
>>>>>>> develop
=======
        Cursor.visible = true;
>>>>>>> origin/julian
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> origin/julian
        SceneManager.LoadScene(Variables.level_names[Variables.starting_level], LoadSceneMode.Single);
=======
>>>>>>> Xellon/develop
        Variables.current_level = Variables.starting_level;
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
    }

    //**************************************************************************************************************************************************************

    public void chooseLevelPress() {
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> develop
=======
>>>>>>> origin/julian
        SceneManager.LoadScene(Variables.level_names[1], LoadSceneMode.Single);
=======
>>>>>>> Xellon/develop
        Variables.current_level = 1;
        SceneManager.LoadScene("LevelChoices", LoadSceneMode.Single);
    }

    //**************************************************************************************************************************************************************

    public void backPress() {
        settings_menu.enabled = false;
        score_menu.enabled = false;

        main_menu.enabled = true;
    }

    //**************************************************************************************************************************************************************

    void Update () {
<<<<<<< HEAD
<<<<<<< HEAD
		
	}
=======
    }
>>>>>>> develop
=======
    }
>>>>>>> origin/julian

    //**************************************************************************************************************************************************************

}
