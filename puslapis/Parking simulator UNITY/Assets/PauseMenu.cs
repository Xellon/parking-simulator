using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    public Transform pause_langas;
    public Transform player;

    // Use this for initialization
    void Start() {
       pause_langas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            pausePress();
        }
    }


    public void pausePress() {
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

    /* public void restartPress(){

     }*/


    /*public void mainPress(){
     
    }*/

    /*public void levelPress(){

    }*/


}
