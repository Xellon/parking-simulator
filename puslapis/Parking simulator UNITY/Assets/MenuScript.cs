using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public Canvas MainMenu;
    public Canvas SettingsMenu;
    public Canvas AboutMenu;
    public Canvas ScoreMenu;

	// Use this for initialization
	void Start () {
        MainMenu = MainMenu.GetComponent<Canvas>();
        SettingsMenu= SettingsMenu.GetComponent<Canvas>();
        AboutMenu = AboutMenu.GetComponent<Canvas>();
        ScoreMenu = ScoreMenu.GetComponent<Canvas>();

        SettingsMenu.enabled = false;
        ScoreMenu.enabled = false;
        AboutMenu.enabled = false;

        MainMenu.enabled = true;
    }
	
    public void ScorePress(){
        ScoreMenu.enabled = true;

        MainMenu.enabled = false;
        SettingsMenu.enabled = false;
        AboutMenu.enabled = false;
    }

    public void SettingsPress(){
        ScoreMenu.enabled = false;
        MainMenu.enabled = false;
        AboutMenu.enabled = false;

        SettingsMenu.enabled = true;
    }

    public void AboutPress()
    {
        ScoreMenu.enabled = false;
        MainMenu.enabled = false;
        SettingsMenu.enabled = false;

        AboutMenu.enabled = true;
    }

    public void PlayPress()
    {

    }

    public void BackPress(){

        SettingsMenu.enabled = false;
        ScoreMenu.enabled = false;
        AboutMenu.enabled = false;

        MainMenu.enabled = true;
    }

    /*public void StartLevel()
    {
        Application.LoadLevel(1);
        
    }*/
	
    // Update is called once per frame
    void Update () {
		
	}
}
