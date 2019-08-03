using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;
    // Use this for initialization
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

        bool shoot = Input.GetButtonDown("Fire1");
        bool altFire = Input.GetButtonDown("Fire2");

        if (shoot)
        {
            RaycastHit hit;
            if (!Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            }
            else
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }
        }
    }
}

