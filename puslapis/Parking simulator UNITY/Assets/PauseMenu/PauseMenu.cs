using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Transform pause_langas;
    public Transform player;

    // Use this for initialization
    void Start() {
       pause_langas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pausePress();
        }
    }


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

    public void resume(){
        Cursor.visible = false;
        Time.timeScale = 1;
        pause_langas.gameObject.SetActive(false);
        
        player.GetComponent<FirstPersonController>().enabled = true;
        
    }

    public void restart(){
        SceneManager.LoadScene("test platform", LoadSceneMode.Additive);

        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void levelSelect(){

        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void mainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);

        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
