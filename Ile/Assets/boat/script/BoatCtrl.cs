using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCtrl : MonoBehaviour
{
    public float speed = 3; // boat velocity
    private float force; // rear / front
    private float dir; //left / right
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //force et direction
        force = Mathf.SmoothStep(force, Input.GetAxis("Vertical"), Time.deltaTime * 10);
        dir = Mathf.SmoothStep(dir, Input.GetAxis("Horizontal"), Time.deltaTime * 5);
        // application velocite au rigidbody pour avancer
        Vector3 velocity = new Vector3(0,force*speed, 0);
        rb.velocity = rb.transform.TransformDirection(velocity);
        // rotation pr la direction
        Vector3 angularVel = new Vector3(0,dir * speed/2, 0);
        rb.angularVelocity = angularVel;
    }

    // Update is called once per frame
}
