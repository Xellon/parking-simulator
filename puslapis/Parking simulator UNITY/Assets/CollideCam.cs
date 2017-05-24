using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideCam : MonoBehaviour
{

    private Rigidbody vehicle;
    private Camera collideCam;

    [Range(-5.0f, 5.0f)]
    public float camHeight;

    [Range(-5.0f, 5.0f)]
    public float camRadius; 

    [Range(0.0f, 5.0f)]
    public float orbitSpeed;

    public GameObject buttonPrefab;
    private GameObject resetButton;

    private float timeCount = 0;

    private Vector3     initPos;
    private Quaternion  initRot;

    void Start()
    {
        vehicle = GetComponent<Rigidbody>();
        if(vehicle == null)
        {
            Debug.Log("Vehicle objektas nenustatytas!");
        }

        // initial position to reset the level
        initPos = vehicle.transform.position;
        initRot = vehicle.transform.rotation;

        // cam creation
        collideCam = new GameObject("CollideCamera").AddComponent<Camera>();
        collideCam.transform.parent = vehicle.transform;
        collideCam.gameObject.SetActive(false);

        // button creation
        resetButton = Instantiate(buttonPrefab);
        resetButton.SetActive(false);
        resetButton.transform.SetParent(GameObject.FindWithTag("MainUI").transform); // using MainUI tag set in inspector
        resetButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
        resetButton.GetComponent<Button>().onClick.AddListener(ResetLevel); // function to do on click
    }

    void Update()
    {
        if(collideCam.gameObject.activeSelf)
        {
            timeCount += Time.deltaTime * orbitSpeed;

            // orbit camera
            collideCam.transform.position = new Vector3(
                vehicle.transform.position.x + Mathf.Cos(timeCount) * camRadius,
                vehicle.transform.position.y + camHeight,
                vehicle.transform.position.z + Mathf.Sin(timeCount) * camRadius
                );

            // focus camera on the vehicle
            collideCam.transform.LookAt(vehicle.transform);
        }
        
    }

    public void OnCollisionEnter(Collision other)
    {
        collideCam.gameObject.SetActive(true);
        resetButton.SetActive(true);

        Cursor.visible = true;

        // freeze vehicle
        vehicle.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ResetLevel()
    {
        Cursor.visible = false;

        // reset vehicle pos to original
        vehicle.transform.SetPositionAndRotation(initPos, initRot);

        resetButton.SetActive(false);
        collideCam.gameObject.SetActive(false);
        timeCount = 0;

        // unfreeze vehicle
        vehicle.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}