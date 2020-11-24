using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicktoMove : MonoBehaviour
{
    //deplacement
    private float speed = 0.1f;
    public float rotationSpeed = 2.3f;

    
    private Rigidbody rb;
    private Animator anim;
    public Vector3 jumpSpeed;
    private CapsuleCollider cc;
    private bool Rinisontheground = true;

    
    void Start()
    {
        //deplacement
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider>();
    }


    private void Update()
    {
        
        //deplacement

        if (Input.GetKey(KeyCode.UpArrow) && Rinisontheground) // Avancer droit devant
        {
            if (Input.GetKey(KeyCode.LeftShift)) //accelerer
            {
                anim.SetBool("strafe right",false);
                anim.SetBool("strafe left",false);
                anim.SetBool("Walk_backward",false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", true);
                float z = Input.GetAxis("Vertical") * speed*2;
                float y = Input.GetAxis("Horizontal") * rotationSpeed;
                transform.Translate(0, 0, z);
                transform.Rotate(0, y, 0);
            }
            else // avancer
            {
                anim.SetBool("strafe right",false);
                anim.SetBool("strafe left",false);
                anim.SetBool("Run",false);
                anim.SetBool("Walk_backward",false);
                anim.SetBool("Walk",true);
                float z = Input.GetAxis("Vertical") * speed;
                float y = Input.GetAxis("Horizontal") * rotationSpeed;
                transform.Translate(0, 0, z);
                transform.Rotate(0, y, 0);
            }
            
        }

        else if (Input.GetKey(KeyCode.RightArrow) && (!(Input.GetKey(KeyCode.UpArrow)) && Rinisontheground)) //deplacement pas horizontaux
        {
            anim.SetBool("Run",false);
            anim.SetBool("Walk",false);
            anim.SetBool("strafe left",false);
            anim.SetBool("strafe right",true);
            float x = Input.GetAxis("Horizontal") * speed * 0.8f;
            transform.Translate(x,0,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && (!(Input.GetKey(KeyCode.UpArrow)) && Rinisontheground)) //deplacement pas horizontaux
        {
            anim.SetBool("Run",false);
            anim.SetBool("Walk",false);
            anim.SetBool("strafe right",false);
            anim.SetBool("strafe left",true);
            float x = Input.GetAxis("Horizontal") * speed * 0.8f;
            transform.Translate(x,0,0);
        }
        
        
        else if (Input.GetKey(KeyCode.DownArrow) && Rinisontheground) // reculer
        {
            anim.SetBool("strafe right",false);
            anim.SetBool("strafe left",false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Walk_backward", true);
            float z = Input.GetAxis("Vertical") * (speed) * 0.8f;
            transform.Translate(0, 0, z);
        }
        else // initialisation booleens
        {
            anim.SetBool("strafe right",false);
            anim.SetBool("strafe left",false);
            anim.SetBool("Walk_backward",false);
            anim.SetBool("Walk",false);
            anim.SetBool("Run",false);
        }




        if (Rinisontheground && Input.GetKeyUp(KeyCode.Space)) // jump
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity * Time.deltaTime; 
            v.y = jumpSpeed.y;
            anim.SetBool("Jump", true);
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
            Rinisontheground = false;
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        // attack
        if (Input.GetKeyUp(KeyCode.W) && Rinisontheground)
        {
            anim.SetBool("Attack",true);
        }
        else
        {
            anim.SetBool("Attack",false);
        }
        // esquive
        if (Rinisontheground && Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("dodge_right",true);
        }
        else
        {
            anim.SetBool("dodge_right",false);
        }

        if (Rinisontheground && Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("dodge_left",true);
        }
        else
        {
            anim.SetBool("dodge_left",false);
        }
        

    }
     // Collision avec le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Rinisontheground = true;
        }
    }

    
}
