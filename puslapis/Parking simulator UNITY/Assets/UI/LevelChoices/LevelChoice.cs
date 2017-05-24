﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChoice : MonoBehaviour {

    private GameObject template;
    private Transform background;

    private Vector2 button_size;

    private int space = 50;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public int rows;
    public int columns;
=======
    private int rows;
    private int columns;
>>>>>>> origin/julian
=======
    public int rows;
    public int columns;
>>>>>>> develop
=======
    public int rows=3;
    public int columns=8;
>>>>>>> Xellon/develop
    //**************************************************************************************************************************************************************

    void Start () {
        template = GameObject.Find("ButtonLevel");

        button_size = new Vector2(template.GetComponent<RectTransform>().rect.width, template.GetComponent<RectTransform>().rect.height);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        //rows = 3; //(int)(Screen.width / button_size.x + space);
        //columns = 8; //(int)((Screen.height - 300) / button_size.y + space);
=======
        rows = 3;//(int)(Screen.width / button_size.x + space);
        columns = 8;//(int)((Screen.height - 300) / button_size.y + space);
>>>>>>> origin/julian
=======
        //rows = 3; //(int)(Screen.width / button_size.x + space);
        //columns = 8; //(int)((Screen.height - 300) / button_size.y + space);
>>>>>>> develop
=======
>>>>>>> Xellon/develop
        float left = (Screen.width - columns * (button_size.x + space) + button_size.x) / 2;
        float top = (Screen.height - rows * (button_size.y + space) + button_size.x) / 2;
        float height = Screen.height - top * 2;
        Debug.Log(Screen.width + "x" + Screen.height);

<<<<<<< HEAD
<<<<<<< HEAD
        int button_count = 0;

        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < columns; x++) {
                GameObject button = Instantiate(template, new Vector3(left + x * (button_size.x + space), top + height - y * (button_size.y + space)), new Quaternion(), gameObject.transform);
                button.name = "ButtonLevel" + button_count;
                button.transform.FindChild("Text").GetComponent<Text>().text = (button_count).ToString();

                int id = button_count + Variables.starting_level;
=======
=======
        int button_count = 0;

>>>>>>> develop
        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < columns; x++) {
                GameObject button = Instantiate(template, new Vector3(left + x * (button_size.x + space), top + y * (button_size.y + space)), new Quaternion(), gameObject.transform);
                button.name = "ButtonLevel" + button_count;
                button.transform.FindChild("Text").GetComponent<Text>().text = (button_count).ToString();

<<<<<<< HEAD
                int id = y * rows + x + Variables.starting_level;
>>>>>>> origin/julian
=======
                int id = button_count + Variables.starting_level;
>>>>>>> develop
                ColorBlock color = button.GetComponent<Button>().colors;

                if (!String.IsNullOrEmpty(Variables.level_names[id])) {
                    button.GetComponent<Button>().onClick.AddListener(() => { startLevel(id); });

                    //color.normalColor = new Color(0.8f, 0.8f, 0.9f, 1);
                    button.transform.FindChild("Text").GetComponent<Text>().color = new Color32(0x00, 0x8C, 0xDF, 0xFF); //008CDFFF
                    color.normalColor = Color.white;
                    color.highlightedColor = new Color32(0xEE, 0xEE, 0xFF, 0xFF); //#8EDAFF41
                    color.pressedColor = new Color32(0xDD, 0xDD, 0xDD, 0xFF); //00DFFF3C
                    button.GetComponent<Button>().colors = color;

                }
                else {
                    button.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
                    color.normalColor = new Color32(0x00, 0x00, 0x19, 0x41); //#00001941
                    color.highlightedColor = new Color32(0x00, 0x00, 0x00, 0x66); //#8EDAFF41
                    color.pressedColor = new Color32(0x00, 0x00, 0x00, 0x66); //00DFFF3C
                    button.GetComponent<Button>().colors = color;
                }
<<<<<<< HEAD
<<<<<<< HEAD

                button_count++;
=======
>>>>>>> origin/julian
=======

                button_count++;
>>>>>>> develop
            }
        }
    }

    private void Instantiate() {
        throw new NotImplementedException();
    }

    //**************************************************************************************************************************************************************

    void Update () {
		
	}

    //**************************************************************************************************************************************************************

    public static void startLevel(int level_id) {
        Variables.current_level = level_id;
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
    }

    //**************************************************************************************************************************************************************
}
