using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyEnterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the player collides with the building, go to the end scene
    private void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("EndScene");
    }
}
