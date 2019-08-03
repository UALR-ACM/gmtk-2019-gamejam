using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionEffect;
    private void Update()
    {
        transform.Rotate(20, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: Enter damage numbers and add any explosion effects
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        //explosion.transform.parent = transform;
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
