using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCam : MonoBehaviour
{

    private Rigidbody vehicle;

    // Use this for initialization
    void Start()
    {
        vehicle = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
    }
}