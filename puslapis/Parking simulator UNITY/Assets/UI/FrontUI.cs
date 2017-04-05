using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FrontUI : MonoBehaviour {

    public Canvas frontUI;

    private GameObject car;

    private Image steering_wheel;
    private Text wheel_text_L;
    private Text wheel_text_R;
    private Text wheel_speed;

    private float rotation = 0.0f;
    private float sprite_rotation = 0.0f;
    private float delta_rotation = 0.0f;
    private float max_rotation = 2.0f;

    Vector3 last_pos;

    // Use this for initialization
    void Start () {
        car = GameObject.FindGameObjectWithTag("PlayerCar");
        last_pos = car.transform.position;

        frontUI = GetComponent<Canvas>();
        
        steering_wheel = frontUI.transform.FindChild("SpriteWheel").GetComponent<Image>();
        wheel_text_L = frontUI.transform.FindChild("TextWheelTurnR").GetComponent<Text>();
        wheel_text_R = frontUI.transform.FindChild("TextWheelTurnL").GetComponent<Text>();
        wheel_speed = frontUI.transform.FindChild("TextSpeed").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        float speed = (car.transform.position - last_pos).magnitude / Variables.delta_t;

        rotation = Variables.steering_wheel;

        rotation = rotation/max_rotation * 720 * 10;

        delta_rotation = sprite_rotation - rotation;
        sprite_rotation = rotation;
        steering_wheel.rectTransform.Rotate(0, 0, delta_rotation);

        rotation = Mathf.Abs(Mathf.RoundToInt(rotation));
        
        wheel_text_L.text = rotation.ToString() + '°';
        wheel_text_R.text = rotation.ToString() + '°';

        wheel_speed.text = (int)(speed/3.6 * 10) + " Km/h";

        last_pos = car.transform.position;
    }
}
