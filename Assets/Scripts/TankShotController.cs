using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShotController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;

    public GameObject altFireBullet;
    public float shotForce;

    // gameobject we have to ignore collider
    public GameObject tankHead, tankBase;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        //cam = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        bool altFire = Input.GetButtonDown("Fire2");

        if (altFire)
        {
            GameObject cannonShell = Instantiate(altFireBullet, transform.position, transform.rotation);
            //Physics.IgnoreCollision(cannonShell.GetComponent<Collider>(), tankHead.GetComponent<Collider>());
            Physics.IgnoreCollision(cannonShell.GetComponent<Collider>(), tankBase.GetComponent<Collider>());
            cannonShell.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shotForce);

        }

    }
}
