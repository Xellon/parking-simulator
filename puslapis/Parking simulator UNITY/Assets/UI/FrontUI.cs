using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FrontUI : MonoBehaviour {

<<<<<<< HEAD
<<<<<<< HEAD
    public Canvas front_UI;
=======
    private Canvas front_UI;
>>>>>>> develop
=======
    private Canvas front_UI;
>>>>>>> origin/julian

    private GameObject car;

    private Image steering_wheel;
    private Image arrow_L;
    private Image arrow_R;
    private Text wheel_text_L;
    private Text wheel_text_R;
    private Text wheel_speed;

    private float rotation = 0.0f;
    private float sprite_rotation = 0.0f;
    private float delta_rotation = 0.0f;
    private float max_rotation = 2.0f;

<<<<<<< HEAD
<<<<<<< HEAD
    Vector3 last_pos;

=======
    
>>>>>>> develop
=======
    
>>>>>>> origin/julian
    //**************************************************************************************************************************************************************

    void Start () {
        car = GameObject.FindGameObjectWithTag("PlayerCar");
<<<<<<< HEAD
<<<<<<< HEAD
        last_pos = car.transform.position;

=======
>>>>>>> develop
=======
>>>>>>> origin/julian
        front_UI = GetComponent<Canvas>();
        
        steering_wheel = front_UI.transform.FindChild("SpriteWheel").GetComponent<Image>();
        arrow_L = front_UI.transform.FindChild("ArrowL").GetComponent<Image>();
        arrow_R = front_UI.transform.FindChild("ArrowR").GetComponent<Image>();
        wheel_text_L = front_UI.transform.FindChild("TextWheelTurnR").GetComponent<Text>();
        wheel_text_R = front_UI.transform.FindChild("TextWheelTurnL").GetComponent<Text>();
        wheel_speed = front_UI.transform.FindChild("TextSpeed").GetComponent<Text>();

    }

    //**************************************************************************************************************************************************************

    void Update () {
<<<<<<< HEAD
<<<<<<< HEAD
        float speed = (car.transform.position - last_pos).magnitude / Variables.delta_t;

        rotation = Variables.steering_wheel;

=======

        rotation = Variables.steering_wheel;
>>>>>>> develop
=======

        rotation = Variables.steering_wheel;
>>>>>>> origin/julian
        rotation = rotation/max_rotation * 720 * 10;

        delta_rotation = sprite_rotation - rotation;
        sprite_rotation = rotation;
        steering_wheel.rectTransform.Rotate(0, 0, delta_rotation);

        rotation = Mathf.Abs(Mathf.RoundToInt(rotation));
        
        wheel_text_L.text = (rotation / 360).ToString();
        wheel_text_R.text = (rotation / 360).ToString();

        if (sprite_rotation == 0) {
            arrow_L.gameObject.SetActive(false);
            arrow_R.gameObject.SetActive(false);
            wheel_text_L.gameObject.SetActive(true);
            wheel_text_R.gameObject.SetActive(true);
        }
        else if (sprite_rotation < 0) {
            arrow_L.gameObject.SetActive(false);
            arrow_R.gameObject.SetActive(true);
            wheel_text_L.gameObject.SetActive(false);
            wheel_text_R.gameObject.SetActive(true);
        }
        else {
            arrow_L.gameObject.SetActive(true);
            arrow_R.gameObject.SetActive(false);
            wheel_text_L.gameObject.SetActive(true);
            wheel_text_R.gameObject.SetActive(false);
        }

<<<<<<< HEAD
<<<<<<< HEAD
        wheel_speed.text = (int)(speed/3.6 * 10) + " Km/h";

        last_pos = car.transform.position;
=======
        wheel_speed.text = (int)Variables.speed + " Km/h";
>>>>>>> develop
=======
        wheel_speed.text = (int)Variables.speed + " Km/h";
>>>>>>> origin/julian
    }
}
