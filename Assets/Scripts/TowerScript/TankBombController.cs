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

    public float secondaryFireTimer; //Time between primary fires (left-clicks
    private float secondaryFire; //Determines whether or not the weapon can fire

    // origin and direction of bulltes
    public GameObject originBulletLaunch;
    public GameObject firstCam;

    // sound manager
    public GameObject soundManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {

        bool altFire = Input.GetButtonDown("Fire2");

        secondaryFire += Time.deltaTime;



        if (altFire && secondaryFire >= secondaryFireTimer)
        {
            GameObject cannonShell = Instantiate(altFireBullet, originBulletLaunch.transform.position, transform.rotation);
            cannonShell.GetComponent<Rigidbody>().AddForce(firstCam.transform.forward * shotForce);
            soundManager.GetComponent<SoundManager>().PlayCannonShot();
            secondaryFire = 0f;
        }

        secondaryFire += Time.deltaTime;

    }
}
