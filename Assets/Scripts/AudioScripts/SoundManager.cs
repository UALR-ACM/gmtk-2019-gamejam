using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource laserShot;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKey("p"))
        {
            PlayLaserShot();
        }


    }


    public void PlayLaserShot()
    {
        laserShot.Play();
    }

}
