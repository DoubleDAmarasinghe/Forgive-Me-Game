using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blocks : MonoBehaviour
{
    public int scorePoint;

    [SerializeField ]UnityEvent testEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            testEvent.Invoke();
            Destroy(gameObject);
            Debug.Log(this.name);
        }
    }

}
