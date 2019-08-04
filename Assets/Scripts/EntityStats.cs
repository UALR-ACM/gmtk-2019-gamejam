using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

    public GameObject buffOrb;

    public int powerLevel;
    [Range(0f,1f)]
    public float healthPercent;
    [Range(0f, 1f)]
    public float speedPercent;
    [Range(0f, 1f)]
    public float attackPercent;

    private float maxHealth;
    private float currentHealth;
    private float speed;
    private float attack;

    private void Start() {
        maxHealth = healthPercent * powerLevel;
        currentHealth = maxHealth;
        speed = powerLevel * speedPercent;
        attack = powerLevel * attackPercent;

    }

    public void Damage(float dmgAmount) {

        currentHealth -= dmgAmount;

        if (currentHealth < 0f)
        {
            
            float buffDrop = Random.Range(0, 100);
            if (buffDrop >= 50)
            {
                Instantiate(buffOrb, gameObject.transform.position, Quaternion.identity);
                Debug.Log("Orb spawned");
            }
            Destroy(gameObject);
        }
            
    }

    public float getHealthPercent() {
        return this.currentHealth / 100;
    }

    public float getAttack()
    {
        return attack;
    }

    public void upgradeAttack()
    {
        attack += 1;
    }

    public void upgradeSpeed()
    {
        speed += 1;
    }

    public void upgradeHealth()
    {
        maxHealth += 1;
    }
}