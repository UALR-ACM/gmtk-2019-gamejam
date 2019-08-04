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

    

}
