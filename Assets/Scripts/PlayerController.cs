using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        rb.AddForce(direction*speed);
    }

    public void TriggerEvent1()
    {
        Debug.Log("event triggered!!");
    }
}
