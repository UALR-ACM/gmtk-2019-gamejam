using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject tank;
    public GameObject headTank;

    public Camera firstCam;
    public Camera upCam;

    // handle number or deaths and level of the game

    public int numDeadEnemy = 1;
    public int gameLevel = 1;


    //private ScriptableObject towerController, mouseCameraController;

    void Start()
    {

        upCam.enabled = true;
        firstCam.enabled = false;

        //headTank = GameObject.Find("HeadTank");
        headTank.GetComponent<TankShotController>().enabled = false;
        firstCam.GetComponent<MouseCameraController>().enabled = false;

    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            upCam.enabled = !upCam.enabled;
            firstCam.enabled = !firstCam.enabled;

            // disable the possibility to move the tank when we are in first view
            // activate the first shooter view
            tank.GetComponent<TankMouvement>().enabled = !tank.GetComponent<TankMouvement>().enabled;
            headTank.GetComponent<TankShotController>().enabled = !headTank.GetComponent<TankShotController>().enabled;
            firstCam.GetComponent<MouseCameraController>().enabled = !firstCam.GetComponent<MouseCameraController>().enabled;
        }

    }
}
