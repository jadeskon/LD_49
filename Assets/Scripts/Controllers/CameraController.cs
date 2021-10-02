using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Publics
    private GameObject character;
    private GameObject vulcan;


    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        vulcan = GameObject.FindGameObjectWithTag("Vulcan");




    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 lookRotation = vulcan.transform.position - transform.position;

        Quaternion look = Quaternion.LookRotation(lookRotation);

        transform.rotation = look;*/


    }
}
