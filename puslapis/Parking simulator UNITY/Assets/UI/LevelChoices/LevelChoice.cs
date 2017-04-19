using System;
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
    private int rows;
    private int columns;
    //**************************************************************************************************************************************************************

    void Start () {
        template = GameObject.Find("ButtonLevel");

        button_size = new Vector2(template.GetComponent<RectTransform>().rect.width, template.GetComponent<RectTransform>().rect.height);
        rows = 3;//(int)(Screen.width / button_size.x + space);
        columns = 8;//(int)((Screen.height - 300) / button_size.y + space);
        float left = (Screen.width - columns * (button_size.x + space) + button_size.x) / 2;
        float top = (Screen.height - rows * (button_size.y + space) + button_size.x) / 2;

        Debug.Log(Screen.width + "x" + Screen.height);

        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < columns; x++) {
                GameObject button = Instantiate(template, new Vector3(left + x * (button_size.x + space), top + y * (button_size.y + space)), new Quaternion(), gameObject.transform);
                button.name = "ButtonLevel" + y * rows + x;
                button.transform.FindChild("Text").GetComponent<Text>().text = (y * rows + x).ToString();

                int id = y * rows + x + Variables.starting_level;
                ColorBlock color = button.GetComponent<Button>().colors;

                if (!String.IsNullOrEmpty(Variables.level_names[id])) {
                    button.GetComponent<Button>().onClick.AddListener(() => { startLevel(id); });

                    color.normalColor = new Color(0.8f, 0.8f, 0.9f, 1);
                    button.GetComponent<Button>().colors = color;

                }
                else {
                    color.normalColor = new Color(0.3f, 0.3f, 0.4f, 1);
                    color.highlightedColor = new Color(0.2f, 0.2f, 0.3f, 1);
                    button.GetComponent<Button>().colors = color;
                }
            }
        }
        background = transform.FindChild("Background");
        background.position = new Vector3(Screen.width/2, Screen.height/2);
        background.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

    }

    private void Instantiate() {
        throw new NotImplementedException();
    }

    //**************************************************************************************************************************************************************

    void Update () {
		
	}

    //**************************************************************************************************************************************************************

    public void startLevel(int level_id) {
        SceneManager.LoadScene(Variables.level_names[level_id], LoadSceneMode.Single);
        Variables.current_level = level_id;
    }

    //**************************************************************************************************************************************************************

}
