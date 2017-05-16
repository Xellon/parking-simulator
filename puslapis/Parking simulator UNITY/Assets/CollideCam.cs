using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCam : MonoBehaviour
{

    private Rigidbody vehicle;
    private Camera collideCam;

    // Use this for initialization
    void Start()
    {
        vehicle = GetComponent<Rigidbody>();
        if(vehicle == null)
        {
            Debug.Log("Vehicle objektas nenustatytas!");
        }

        collideCam = new Camera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Triggered");
    }
}