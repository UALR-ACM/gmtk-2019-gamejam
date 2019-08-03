using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

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

        if(currentHealth < 0f)
            Destroy(this.gameObject);
    }

    public float getHealthPercent() {
        return this.currentHealth / 100;
    }
}