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

    public float smooth;
    private Quaternion targetRotation;

    bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        DirectionalRotation();

        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,10*smooth*Time.deltaTime);
        
        //Debug.Log(this.transform.localEulerAngles.y);

        float horizontal = Input.GetAxis("Horizontal");

        if(this.transform.localEulerAngles.y==0)
        {
            moveVector = new Vector3(horizontal, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        else if(this.transform.localEulerAngles.y == 90)
        {
            moveVector = new Vector3(-horizontal, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        else if(this.transform.localEulerAngles.y==270)
        {
            moveVector = new Vector3(0, 0, horizontal);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }

        else if(this.transform.localEulerAngles.y==180)
        {
            moveVector = new Vector3(0, 0, -horizontal);
            characterController.Move(moveVector*speed*Time.deltaTime);
        }


        //jump
        gravity += Physics.gravity.y * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gravity = JumpHeight;
        }

        
        Vector3 v = moveVector * speed;
        v.y = gravity;
        characterController.Move(v*Time.deltaTime);
        
        
        
        
    }

    void DirectionalRotation()
    {
        //directional rotation to left
        if(Input.GetKeyUp(KeyCode.O))
        {
            targetRotation *= Quaternion.AngleAxis(90,Vector3.up);
        }

        //directional rotation to right
        else if(Input.GetKeyUp(KeyCode.P))
        {
            targetRotation *= Quaternion.AngleAxis(-90,Vector3.up);
            //this.transform.Rotate(0, -90 , 0, Space.World);
        }
    }
}
