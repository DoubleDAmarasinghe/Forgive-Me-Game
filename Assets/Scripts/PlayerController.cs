using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    public float speed;
    bool rotated1 = false;
    bool rotated2 = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        StandingRotation();

        float horizontal = Input.GetAxis("Horizontal");

        if(this.transform.localEulerAngles.y==0)
        {
            Vector3 direction = new Vector3(horizontal, 0, 0);
            characterController.Move(direction*speed);
        }

        else if(this.transform.localEulerAngles.y==180)
        {
            Vector3 direction = new Vector3(-horizontal, 0, 0);
            characterController.Move(direction*speed);
        }

        else if(this.transform.localEulerAngles.y==270)
        {
            Vector3 direction = new Vector3(0, 0, horizontal);
            characterController.Move(direction*speed);
        }

        else if(this.transform.localEulerAngles.y==90)
        {
            Vector3 direction = new Vector3(0, 0, -horizontal);
            characterController.Move(direction*speed);
        }
        
        
        Debug.Log(this.transform.localEulerAngles.y);
        
    }

    void StandingRotation()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //Debug.Log("rotated left");
            this.transform.Rotate(0, 90 , 0, Space.World);
            rotated1 = true;
            rotated2 = false;

        }

        else if(Input.GetKeyUp(KeyCode.Backspace))
        {
            //Debug.Log("rotated right");
            this.transform.Rotate(0, -90 , 0, Space.World);
            rotated1 = true;
            rotated2 = false;

        }
    }
}
