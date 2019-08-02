using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject tank;
    public Camera firstCam;
    public Camera upCam;

    void Start()
    {
        upCam.enabled = true;
        firstCam.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            upCam.enabled = !upCam.enabled;
            firstCam.enabled = !firstCam.enabled;

            // disable the possibility to move the tank when we are in first view
            tank.GetComponent<TankMouvement>().enabled = !tank.GetComponent<TankMouvement>().enabled;
        }

    }
}
