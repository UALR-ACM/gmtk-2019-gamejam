using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{

    private float currentWallHealth; 
    private GameObject healthBar;

    void Start()
    {
        //maxHealth = wallHealthPanel.localScale.x;

        healthBar = transform.GetChild(0).gameObject;

        // yMaz = 700
        currentWallHealth = healthBar.transform.localScale.y;

        //Debug.Log("Max Health");
        //Debug.Log(currentWallHealth);

    }

    void Update()
    {

        //if (Input.GetKeyDown("o"))
        //{
        //    GetDamage(20.0f);
        //}

    }


    public void GetDamage(float damageValue)
    {

        // Debug.Log(damageValue.ToString());
        currentWallHealth -= damageValue;
        // Debug.Log(currentWallHealth);

        if (currentWallHealth <= 0)
        {
            currentWallHealth = 0f;
            Destroy(this.transform.parent.gameObject); 
        }

        Vector3 newSize = new Vector3(80.0f, currentWallHealth, 80.0f);
        healthBar.transform.localScale = newSize;

    }

}
