using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    GameObject cam;
    public LineRenderer trail;
    public float trailWidth = 0.1f;
    public float maxTrailLength = 5f;
    public float bulletDamage = 1f;
    public float primaryFireTimer; //Time between primary fires (left-clicks
    private float primaryFire; //Determines whether or not the weapon can fire

    void Start()
    {
        Vector3[] trailInit = new Vector3[2] { Vector3.zero, Vector3.zero };
        trail.SetPositions(trailInit);
        trail.startWidth = trailWidth;
        trail.endWidth = trailWidth;
        cam = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && primaryFire >= primaryFireTimer)
        {
            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            RaycastHit hit;
            Vector3 barrelExit = transform.position;
            barrelExit.y -= 0.5f;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
                //Do damage stuff here
                if (hit.rigidbody != null)
                {
                    if (hit.rigidbody.gameObject.CompareTag("Enemy"))
                    {
                        EntityStats enemy = hit.rigidbody.gameObject.GetComponent<EntityStats>();
                        enemy.Damage(bulletDamage);
                    }
                }
            }

            ShowTrail(barrelExit, cam.transform.forward, maxTrailLength);
            trail.enabled = true;
            primaryFire = 0f;
        }
        else
        {
            trail.enabled = false;
        }
        primaryFire += Time.deltaTime;
    }

    //Displays a line representing the path of the ray using the position of the tower, and the position of any object that the ray collides with
    void ShowTrail(Vector3 targetPosition, Vector3 bulletDirection, float length)
    {
        Ray ray = new Ray(targetPosition, bulletDirection);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * bulletDirection);

        if(Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        trail.SetPosition(0, targetPosition);
        trail.SetPosition(1, endPosition);
    }
}
