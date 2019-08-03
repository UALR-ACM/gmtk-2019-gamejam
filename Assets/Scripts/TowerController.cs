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

        //if (shoot && PauseMenu.GameIsPaused != true)
        //{
        //    shootBullet();
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PauseMenu.GameIsPaused = true;
        //}

    }

    //protected void LateUpdate()
    //{
    //    transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    //}

    //private void ShootBullet()
    //{
    //    Rigidbody bulletInstance = Instantiate(m_Bullet, (transform.position + Camera.main.transform.forward * 2), m_FireTransform.rotation) as Rigidbody;
    //    bulletInstance.velocity = m_FireTransform.forward * 10;

    //}
}

