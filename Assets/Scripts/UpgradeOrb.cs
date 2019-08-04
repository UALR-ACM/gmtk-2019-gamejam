using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOrb : MonoBehaviour
{

    public Material[] materials;
    Renderer rend;
    public int buffIndex;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        int buff = Random.Range(0, 3);
        buffIndex = Mathf.RoundToInt(buff);
        rend.material = materials[buffIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        Material testMat = rend.material;
        //GameObject triggerHandler = other.gameObject;
        if (testMat.name == "DamageBuff (Instance)")
        {
            other.gameObject.GetComponent<EntityStats>().UpgradeAttack();
            Debug.Log("Attack Increased");
        }
        else if (testMat.name == "SpeedBuff (Instance)")
        {
            other.gameObject.GetComponent<EntityStats>().UpgradeSpeed();
            Debug.Log("Speed Increased");
        }
        else
        {
            //other.gameObject.GetComponent<EntityStats>().UpgradeHealth();
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach(GameObject thing in walls)
            {
                thing.GetComponent<WallController>().health += 10;
                Debug.Log(thing.GetComponent<WallController>().health);
            }
        }

        Destroy(gameObject);
    }
}
