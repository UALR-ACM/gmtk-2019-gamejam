﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotController : MonoBehaviour
{
    GameObject cam;
    private LineRenderer trail;

    public float trailWidth = 0.1f;
    public float maxTrailLength = 50f;
    public float bulletDamage = 1f;
    public float primaryFireTimer; //Time between primary fires (left-clicks
    private float primaryFire; //Determines whether or not the weapon can fire

    public GameObject launchIngBullet;

  

    void Start()
    {
        trail = gameObject.GetComponent<LineRenderer>();

        // Vector3[] trailInit = new Vector3[2] { Vector3.zero, Vector3.zero };

        cam = transform.parent.gameObject;

        trail.SetPosition(0, launchIngBullet.transform.position);
        trail.SetPosition(1, launchIngBullet.transform.position);

        trail.startWidth = trailWidth;
        trail.endWidth = trailWidth;

    }

    void Update()
    {

        if (Input.GetMouseButton(0) && primaryFire >= primaryFireTimer)
        {

            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            RaycastHit hit;

            //Vector3 barrelExit = transform.position;
            //barrelExit.y -= 0.5f;

            //if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask))
            //{
            //    Debug.Log("here");
            //    //Do damage stuff here
            //    //if (hit.rigidbody.gameObject.CompareTag("Enemy"))
            //    //{
            //    //    EntityStats enemy = hit.rigidbody.gameObject.GetComponent<EntityStats>();
            //    //    enemy.Damage(bulletDamage);
            //    //}
            //}

            ShowTrail(launchIngBullet.transform.position, cam.transform.forward, maxTrailLength);
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
    void ShowTrail(Vector3 originPosition, Vector3 bulletDirection, float length)
    {
        Ray ray = new Ray(originPosition, bulletDirection);

        RaycastHit raycastHit;
        Vector3 endPosition = originPosition + (length * bulletDirection);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            if (raycastHit.transform.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit ennemy");
                endPosition = raycastHit.point;

                // apply damages
                var enemy = raycastHit.transform.gameObject;
                var enemyStats = enemy.GetComponent<EntityStats>();
                enemyStats.Damage(0.1f);
            }

        }

        trail.SetPosition(0, originPosition);
        trail.SetPosition(1, endPosition);
    }


}
