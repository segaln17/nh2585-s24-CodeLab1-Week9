using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    //declare rigidbody
    Rigidbody rb;
    
    //declare and set amount of force to be applied
    public float forceAmt = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        //get access to rigidbody for the gameobject this script is on
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if hitting A, go left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmt);
        }

        //if hitting W, go forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * forceAmt);
            //Debug.Log("Pressed W");
        }

        //if hitting D, go right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmt);
        }
        
        //if hitting S, go backwards
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * forceAmt);
        }
    }
}
