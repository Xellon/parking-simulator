using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private Transform pause_langas;
    private Transform player;

    //**************************************************************************************************************************************************************

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pause_langas = transform.FindChild("PauseMenu");
        pause_langas.gameObject.SetActive(false);

    }

    //**************************************************************************************************************************************************************

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Return)) {
            pausePress();
        }
    }

    //**************************************************************************************************************************************************************

    public void pausePress() {
        Cursor.visible = true;
        if (pause_langas.gameObject.activeInHierarchy == false) {
            pause_langas.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
        else {
            pause_langas.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    //**************************************************************************************************************************************************************

    public void resume(){
        Cursor.visible = false;
        Time.timeScale = 1;
        pause_langas.gameObject.SetActive(false);
        
        player.GetComponent<FirstPersonController>().enabled = true;
        
    }

    //**************************************************************************************************************************************************************

    public void restart(){
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        SceneManager.LoadScene(Variables.level_names[Variables.current_level], LoadSceneMode.Single);
=======
        int scene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
>>>>>>> develop
=======
        SceneManager.LoadScene(Variables.level_names[Variables.current_level], LoadSceneMode.Single);
>>>>>>> origin/julian
=======
        int scene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(scene, LoadSceneMode.Single);
>>>>>>> develop

        Cursor.visible = false;
        Time.timeScale = 1;
=======
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
>>>>>>> Xellon/develop
    }

    //**************************************************************************************************************************************************************

    public void levelSelect(){
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
        SceneManager.LoadScene(Variables.level_names[1], LoadSceneMode.Single);
        Variables.current_level = 1;
>>>>>>> develop
=======
        SceneManager.LoadScene(Variables.level_names[1], LoadSceneMode.Single);
        Variables.current_level = 1;
>>>>>>> origin/julian
        Cursor.visible = false;
        Time.timeScale = 1;
=======
        Variables.current_level = 1;
        SceneManager.LoadScene("LevelChoices", LoadSceneMode.Single);
>>>>>>> Xellon/develop
    }

    //**************************************************************************************************************************************************************

    public void nextLevel() {
        Variables.current_level++;
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
    }

    //**************************************************************************************************************************************************************

    public void mainMenu() {
        Variables.current_level = 0;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
