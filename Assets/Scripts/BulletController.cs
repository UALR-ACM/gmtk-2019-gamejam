using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionRadius = 10f;
    public float power; 
    private void Update()
    {
        transform.Rotate(20, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: Enter damage numbers
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        Vector3 explosionPos = transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(rb != null)
            {


                rb.AddExplosionForce(power, explosionPos, explosionRadius);

                //if (!rb.gameObject.CompareTag("Player"))
                //{
                //    rb.AddExplosionForce(power, explosionPos, explosionRadius);
                //}

                //if (rb.gameObject.CompareTag("Enemy"))
                //{
                //    EntityStats explodedVictim = rb.gameObject.GetComponent<EntityStats>();
                //    explodedVictim.Damage(this.gameObject.GetComponent<EntityStats>().getAttack());
                //}
            }
        }

        Destroy(gameObject);
        Destroy(explosion, 2);
    }
}
