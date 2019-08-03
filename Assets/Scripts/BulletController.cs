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

            //Debug.Log(hit.transform.gameObject.name.ToString());
            Debug.Log(hit.transform.gameObject.tag);


            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy touch");

                GameObject enemy = hit.transform.gameObject;
                var enemyStats = enemy.GetComponent<EntityStats>();
                enemyStats.Damage(0.1f);


            }


            // Enemy don't have any rigidbody for now
            //if (rb != null)
            //{

            //    //Debug.Log("rb touch");


            //    rb.AddExplosionForce(power, explosionPos, explosionRadius);

            //    //if (!rb.gameObject.CompareTag("Player"))
            //    //{
            //    //    rb.AddExplosionForce(power, explosionPos, explosionRadius);
            //    //}

            //    //if (hit.transform.gameObject.CompareTag("Enemy"))
            //    //{
            //    //    Debug.Log("Enemy touch");

            //    //    GameObject enemy = hit.transform.gameObject;
            //    //    var enemyStats = enemy.GetComponent<EntityStats>();
            //    //    enemyStats.Damage(0.1f);


            //    //}

            //    //if (rb.gameObject.CompareTag("Enemy"))
            //    //{

            //    //    Debug.Log("rb of an ennemy");

            //    //    //EntityStats explodedVictim = rb.gameObject.GetComponent<EntityStats>();
            //    //    //explodedVictim.Damage(this.gameObject.GetComponent<EntityStats>().getAttack());
            //    //}
            //}




        }

        Destroy(gameObject);
        Destroy(explosion, 2);
    }
}
