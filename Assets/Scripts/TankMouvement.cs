using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMouvement : MonoBehaviour
{

    public float speedMouvement = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {

        mouvePlayer();

    }


    public void mouvePlayer()
    {



        if (Input.GetKey("a"))
        {
            gameObject.transform.position += Vector3.left * speedMouvement * Time.deltaTime;
        }


        if (Input.GetKey("d"))
        {
            gameObject.transform.position += Vector3.right * speedMouvement * Time.deltaTime;
        }


        if (Input.GetKey("w"))
        {
            gameObject.transform.position += Vector3.forward * speedMouvement * Time.deltaTime;
        }


        if (Input.GetKey("s"))
        {
            gameObject.transform.position += Vector3.back * speedMouvement * Time.deltaTime;
        }



    }

    public void OnTriggerEnter(Collider other)
    {
        Renderer rend = other.GetComponent<Renderer>();
        Material testMat = rend.material; 
        if(other.gameObject.CompareTag("UpgradeOrb")){
            //GameObject triggerHandler = other.gameObject;
            if(testMat.name == "DamageBuff")
            {
                gameObject.GetComponent<EntityStats>().upgradeAttack();
            }else if (testMat.name == "SpeedBuff")
            {
                gameObject.GetComponent<EntityStats>().upgradeSpeed();
            }
            else
            {
                gameObject.GetComponent<EntityStats>().upgradeHealth();
            }
        }

        Destroy(other.gameObject);
    }
}
