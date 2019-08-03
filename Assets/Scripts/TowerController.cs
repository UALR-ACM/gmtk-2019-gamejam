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
    public float primaryFireTimer; //Time between primary fires (left-clicks)
    private float primaryFire; //Determines whether or not the weapon can fire
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

        bool shoot = Input.GetMouseButton(0);
        bool altFire = Input.GetButtonDown("Fire2");

        if (shoot && primaryFire >= primaryFireTimer)
        {
            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            RaycastHit hit;
            if (!Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            }
            else
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, layerMask);
            }
            primaryFire = 0f;
        }

        if (altFire)
        {
            GameObject cannonShell = Instantiate(altFireBullet, transform.position, transform.rotation);
            Physics.IgnoreCollision(cannonShell.GetComponent<Collider>(), GetComponent<Collider>());
            cannonShell.GetComponent<Rigidbody>().AddForce(cam.transform.forward * shotForce);
            
        }

        primaryFire += Time.deltaTime;
    }
}

