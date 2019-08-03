using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;
    
    public GameObject altFireBullet;
    public GameObject regBullet;
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
            //GameObject bullet = Instantiate(regBullet, transform.localPosition, transform.rotation);
            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            RaycastHit hit;

            //-------------------------BROKEN---------------------------
            //LineRenderer line = gameObject.AddComponent<LineRenderer>();
            //line.startColor = Color.yellow;
            //line.endColor = Color.yellow;
            //line.startWidth = 10f;
            //line.endWidth = 10f;
            //line.useWorldSpace = true;
            //line.SetPosition(0, transform.position);
            //GameObject bullet = Instantiate(regBullet, transform.position, transform.rotation);
            //----------------------------------------------------------


            if (!Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                //bullet.transform.Translate(hit.point);
                //line.SetPosition(1, hit.point);
            }
            else
            {
                Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, layerMask);
                //bullet.transform.Translate(hit.point);
                //line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1000));
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

