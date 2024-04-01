using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    Rigidbody rb;
    public float forceAmt = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmt);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * forceAmt);
            //Debug.Log("Pressed W");
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmt);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * forceAmt);
        }
    }
}
