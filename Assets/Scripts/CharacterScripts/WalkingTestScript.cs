using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTestScript : MonoBehaviour
{

    public float charactSpeed = 1.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * charactSpeed;
    }
}
