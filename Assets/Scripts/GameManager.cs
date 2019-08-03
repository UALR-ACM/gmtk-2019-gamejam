using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] EnemySpawner enemySpawner = default;
    public GameObject tank;
    public GameObject headTank;
    public Camera firstCam;
    public Camera upCam;

    //private ScriptableObject towerController, mouseCameraController;

    void Start() {
        upCam.enabled = true;
        firstCam.enabled = false;

        //headTank = GameObject.Find("HeadTank");
        headTank.GetComponent<TowerController>().enabled = false;
        headTank.GetComponent<MouseCameraController>().enabled = false;

    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            upCam.enabled = !upCam.enabled;
            firstCam.enabled = !firstCam.enabled;

            // disable the possibility to move the tank when we are in first view
            // activate the first shooter view
            tank.GetComponent<TankMouvement>().enabled = !tank.GetComponent<TankMouvement>().enabled;
            headTank.GetComponent<TowerController>().enabled = !headTank.GetComponent<TowerController>().enabled;
            headTank.GetComponent<MouseCameraController>().enabled = !headTank.GetComponent<MouseCameraController>().enabled;
        }

    }
}
