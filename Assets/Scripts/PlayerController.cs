using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject CharacterMesh;
    CharacterController characterController;
    private Vector3 moveVector;
    float moveSpeed;
    public float speed;
    public float JumpHeight;
    private float gravity;
    public float smooth;
    public GameObject Base;
    bool toggle = false;
    private Quaternion targetRotation;
    int compass = 0;

    bool moveRight;
    bool moveLeft;

   
    bool IsLeft;
    
    bool IsRight;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        targetRotation = transform.rotation;
        IsRight = true;
        IsLeft = false;
        moveSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,10*smooth*Time.deltaTime);

        ResetCompass();
        //DirectionalRotation();
        MovementLogic();
        Jump();

        //making a custom gravity
        gravity += Physics.gravity.y * Time.deltaTime;  
    }

    public void PointerRightDown()
    {
        moveRight = true;
        moveSpeed = 1.0f;
    }

   public void PointerRightUp()
    {
        moveRight = false;
        moveSpeed = 0.0f;
    }

   public void PointerLeftDown()
    {
        moveLeft = true;
        moveSpeed = -1.0f;
    }

   public void PointerLeftUp()
    {
        moveLeft = false;
        moveSpeed = 0.0f;
    }

    void MovementLogic()
    {
        
        
        if(compass == 0)
        {
            moveVector = new Vector3(moveSpeed, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);
            
            //character faced direction
            if(moveSpeed > 0 && !IsRight)
            {
                Base.transform.Rotate(0,180,0);
                IsRight = true;
                IsLeft = false;
            }
            else if(moveSpeed < 0 && !IsLeft)
            {
                Base.transform.Rotate(0,180,0);
                IsLeft = true;
                IsRight = false;
            }
        }

        if(compass == 3 || compass == -1)
        {
            moveVector = new Vector3(0, 0, moveSpeed);
            characterController.Move(moveVector*speed*Time.deltaTime);

            //character faced direction
            if(moveSpeed > 0 && !IsRight)
            {
                Base.transform.Rotate(0,180,0);
                IsRight = true;
                IsLeft = false;
            }
            else if(moveSpeed < 0 && !IsLeft)
            {
                Base.transform.Rotate(0,180,0);
                IsLeft = true;
                IsRight = false;
            }
             
        }

        if(compass == 2 || compass == -2)
        {
            moveVector = new Vector3(-moveSpeed, 0, 0);
            characterController.Move(moveVector*speed*Time.deltaTime);

            //character faced direction
            if(moveSpeed > 0 && !IsRight)
            {
                Base.transform.Rotate(0,180,0);
                IsRight = true;
                IsLeft = false;
            }
            else if(moveSpeed < 0 && !IsLeft)
            {
                Base.transform.Rotate(0,180,0);
                IsLeft = true;
                IsRight = false;
            }
            
        }

        if(compass == 1 || compass == -3)
        {
            moveVector = new Vector3(0, 0, -moveSpeed);
            characterController.Move(moveVector*speed*Time.deltaTime);

            //character faced direction
            if(moveSpeed > 0 && !IsRight)
            {
                Base.transform.Rotate(0,180,0);
                IsRight = true;
                IsLeft = false;
            }
            else if(moveSpeed < 0 && !IsLeft)
            {
                Base.transform.Rotate(0,180,0);
                IsLeft = true;
                IsRight = false;
            }
            
            
        }
   
    }

    public void DirectionalRotationLeft()
    {
        //directional rotation to left
        targetRotation *= Quaternion.AngleAxis(90,Vector3.up);
        toggle=!toggle;
        compass += 1;

        
    }

    public void DirectionalRotationRight()
    {
        //directional rotation to right
        targetRotation *= Quaternion.AngleAxis(-90,Vector3.up);
        toggle=!toggle;
        compass -=1;
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
