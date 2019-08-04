using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cam;

    public GameObject buffOrb;
    public GameObject altFireBullet;
    public float shotForce;
    public float secondaryFireTimer = 5.0f;
    private float secondaryFire = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cam = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        secondaryFire += Time.deltaTime;
        bool altFire = Input.GetButtonDown("Fire2");

        if (altFire && secondaryFire >= secondaryFireTimer)
        {
            GameObject cannonShell = Instantiate(altFireBullet, transform.position, transform.rotation);
            Physics.IgnoreCollision(cannonShell.GetComponent<Collider>(), transform.parent.gameObject.GetComponent<Collider>());
            cannonShell.GetComponent<Rigidbody>().AddForce(cam.transform.forward * shotForce);

            secondaryFire = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            ChangeFireRate(5f);
        }
    }

    //Changes the fire rate of the primary weapon by decreasing the timer threshold. Passing in a lower value will cause the weapon to shoot faster
    public void ChangeFireRate(float newTimer)
    {
        BulletTrail upgradedRate = gameObject.GetComponent<BulletTrail>();
        upgradedRate.primaryFireTimer = newTimer;
    }
    public void ChangeSecondaryFireRate(float newTimer)
    {
        secondaryFireTimer = newTimer;
    }
}
