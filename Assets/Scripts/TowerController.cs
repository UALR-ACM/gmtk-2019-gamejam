using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;
    
    public GameObject altFireBullet;
    public float shotForce;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cam = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
     
        bool altFire = Input.GetButtonDown("Fire2");

        if (altFire)
        {
            GameObject cannonShell = Instantiate(altFireBullet, transform.position, transform.rotation);
            Physics.IgnoreCollision(cannonShell.GetComponent<Collider>(), GetComponent<Collider>());
            cannonShell.GetComponent<Rigidbody>().AddForce(cam.transform.forward * shotForce);
            
        }

    }
}

