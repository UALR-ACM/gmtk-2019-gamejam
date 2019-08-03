using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

    public int powerLevel;
    [Range(0f,1f)]
    public float maxHealth;
    protected float currentHealth;
    [Range(0f, 1f)]
    public float speed;
    [Range(0f, 1f)]
    public float attack;

    private void Start() {
        currentHealth = maxHealth;
    }
}