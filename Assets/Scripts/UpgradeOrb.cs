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
}
