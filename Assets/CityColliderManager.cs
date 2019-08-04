using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityColliderManager : MonoBehaviour
{

    private GameObject soundManager;

    // public  List<Collider> triggerList = new List<Collider>();


    void Start()
    {
        // soundManager = GameObject.Find("SoundManager");
    }

    void Update()
    {

        //if (Input.GetKeyDown("c"))
        //{
        //    Debug.Log(triggerList.Count);
        //    Debug.Log(triggerList[0].transform.name);
        //}


    }



    private void OnTriggerEnter(Collider collider)
    {
        
        //if (collider.gameObject.tag == "Enemy")
        //{

        //    GameObject enemy = collider.transform.gameObject;
        //    enemy.GetComponent<EnemyBehaviour>().StopMouvementAndAttack();

        //    //if the object is not already in the list
        //    if (!triggerList.Contains(collider))
        //    {
        //        Debug.Log("this collider was not here before");
        //        //add the object to the list
        //        triggerList.Add(collider);

        //        Debug.Log(triggerList.ToString());
        //        Debug.Log(triggerList.Count);

        //    }
        //}
    }


    //called when something exits the trigger
    private void OnTriggerExit(Collider collider)
    {
        ////if the object is in the list
        //if (triggerList.Contains(collider))
        //{
        //    //remove it from the list
        //    triggerList.Remove(collider);
        //}
    }




}
