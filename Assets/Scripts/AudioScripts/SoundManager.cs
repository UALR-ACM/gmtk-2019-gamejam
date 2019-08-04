using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource laserShot, cannonShot, destroyBuild;

    void Start()
    {
       
    }

    void Update()
    {
        



    }


    public void PlayLaserShot()
    {
        laserShot.Play();
    }

    public void PlayCannonShot()
    {
        cannonShot.Play();
    }

    public void PlayDestroyBuild()
    {
        destroyBuild.Play();
    }

}
