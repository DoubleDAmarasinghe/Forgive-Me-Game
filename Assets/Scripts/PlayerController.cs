﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject CharacterMesh;
    CharacterController characterController;
    private Vector3 moveVector;
    public float speed;
    public float JumpHeight;
    private float gravity;
    public float smooth;
    bool toggle = false;
    private Quaternion targetRotation;
    int compass = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        ResetCompass();
        Debug.Log(compass);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,10*smooth*Time.deltaTime);

        DirectionalRotation();
        MovementLogic();
        Jump();

        //making a custom gravity
        gravity += Physics.gravity.y * Time.deltaTime;  
    }

    void MovementLogic()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        //  if(toggle)
        // {
        //     moveVector = new Vector3(0, 0, horizontal);
        //     characterController.Move(moveVector*speed*Time.deltaTime);
        // }

        // else if(!toggle)
        // {
        //     moveVector = new Vector3(horizontal, 0, 0);
        //     characterController.Move(moveVector*speed*Time.deltaTime);
        //     //transform.rotation = Quaternion.AngleAxis(180,Vector3.up);
        // }
        //Debug.Log(horizontal);
        if(compass == 0)
        {
            moveVector = new Vector3(horizontal, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        if(compass == 3 || compass == -1)
        {
            moveVector = new Vector3(0, 0, horizontal);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        if(compass == 2 || compass == -2)
        {
            moveVector = new Vector3(-horizontal, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        if(compass == 1 || compass == -3)
        {
            moveVector = new Vector3(0, 0, -horizontal);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        

        

        
        
    }

    void DirectionalRotation()
    {
        //directional rotation to left
        if(Input.GetKeyUp(KeyCode.Q))
        {
            targetRotation *= Quaternion.AngleAxis(90,Vector3.up);
            toggle=!toggle;
            compass += 1;
        }

        //directional rotation to right
        else if(Input.GetKeyUp(KeyCode.E))
        {
            targetRotation *= Quaternion.AngleAxis(-90,Vector3.up);
            toggle=!toggle;
            compass -=1;
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gravity = JumpHeight;
        }

        Vector3 v = moveVector * speed;
        v.y = gravity;
        characterController.Move(v*Time.deltaTime);
    }

    void ResetCompass()
    {
        if(compass == 4 || compass == -4)
        {
            compass = 0;
        }
    }
}
