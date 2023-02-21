using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    private Vector3 moveVector;
    public float speed;

    public float JumpHeight;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionalRotation();
        

        float horizontal = Input.GetAxis("Horizontal");

        if(this.transform.localEulerAngles.y==0)
        {
            moveVector = new Vector3(horizontal, 0, 0);
            characterController.Move(moveVector*speed);
        }

        else if(this.transform.localEulerAngles.y==180)
        {
            moveVector = new Vector3(-horizontal, 0, 0);
            characterController.Move(moveVector*speed);
        }

        else if(this.transform.localEulerAngles.y==270)
        {
            moveVector = new Vector3(0, 0, horizontal);
            characterController.Move(moveVector*speed);
        }

        else if(this.transform.localEulerAngles.y==90)
        {
            moveVector = new Vector3(0, 0, -horizontal);
            characterController.Move(moveVector*speed);
        }


        gravity += Physics.gravity.y * Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.Space))
        {
            gravity = JumpHeight;
            
            Debug.Log("gggggggggggggg");
        }

        
        Vector3 v = moveVector * speed;
        v.y = gravity;
        characterController.Move(v*Time.deltaTime);
        
        
        Debug.Log(this.transform.localEulerAngles.y);
        
    }

    void DirectionalRotation()
    {
        //directional rotation to left
        if(Input.GetKeyUp(KeyCode.O))
        {
            this.transform.Rotate(0, 90 , 0, Space.World);
        }

        //directional rotation to right
        else if(Input.GetKeyUp(KeyCode.P))
        {
            this.transform.Rotate(0, -90 , 0, Space.World);
        }
    }

    void Jump()
    {
        
    }
}
