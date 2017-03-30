using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public Canvas MainMenu;
    public Canvas SettingsMenu;
    public Canvas AboutMenu;
    public Canvas ScoreMenu;

    //public Canvas ScoreMenu;
    //Score menu buttons:
   // public Button BackText;

    //Main menu buttons:
   /* public Button StartText;
    public Button ScoreText;
    public Button AboutText;
    public Button SettingsText;*/

   


	// Use this for initialization
	void Start () {
        MainMenu = MainMenu.GetComponent<Canvas>();
        SettingsMenu= SettingsMenu.GetComponent<Canvas>();
        AboutMenu = AboutMenu.GetComponent<Canvas>();
        ScoreMenu = ScoreMenu.GetComponent<Canvas>();


        /* BackText = BackText.GetComponent<Button>();
         StartText = StartText.GetComponent<Button>();
         ScoreText = ScoreText.GetComponent<Button>();
         AboutText = AboutText.GetComponent<Button>();
         SettingsText = SettingsText.GetComponent<Button>();*/

        SettingsMenu.enabled = false;
        ScoreMenu.enabled = false;
        AboutMenu.enabled = false;

        MainMenu.enabled = true;
        
      //  BackText.enabled = false;
    }
	
    public void ScorePress(){
        ScoreMenu.enabled = true;
       // StartText.enabled = false;
       // ScoreText.enabled = false;
       // AboutText.enabled = false;
      //  SettingsText.enabled = false;

       // BackText.enabled = true;

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
        // StartText.enabled = false;
        // ScoreText.enabled = false;
        //AboutText.enabled = false;
        // SettingsText.enabled = false;

        // BackText.enabled = true;

        SettingsMenu.enabled = false;
        ScoreMenu.enabled = false;
        AboutMenu.enabled = false;

        MainMenu.enabled = true;
    }

  /*  public void NoPress()
    {
        SettingsMenu.enabled = false;
        StartText.enabled = true;
        ScoreText.enabled = true;
        AboutText.enabled = true;
        SettingsMenu.enabled = true;
    }*/

    /*public void StartLevel()
    {
        Application.LoadLevel(1);
        
    }*/
    /*public void ExitGame()
    {
       // Application.Quit();

    }*/
    // Update is called once per frame
    void Update () {
		
	}
}
