using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityColliderManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("test");
        
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("enemt enter");

            GameObject enemy = collider.transform.gameObject;
            enemy.GetComponent<EnemyBehaviour>().StopMouvementAndAttack();

        }
    }
}
