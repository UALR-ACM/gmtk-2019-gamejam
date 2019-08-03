using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBombController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;

    public GameObject altFireBullet;
    public float shotForce;

    // origin and direction of bulltes
    public GameObject originBulletLaunch;
    public GameObject firstCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {

        bool altFire = Input.GetButtonDown("Fire2");

        if (altFire)
        {
            GameObject cannonShell = Instantiate(altFireBullet, originBulletLaunch.transform.position, transform.rotation);
            cannonShell.GetComponent<Rigidbody>().AddForce(firstCam.transform.forward * shotForce);
        }

    }
}
