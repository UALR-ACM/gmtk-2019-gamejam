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

    private Animator charactAnimator;

    private void Start() {

        maxHealth = healthPercent * powerLevel;
        currentHealth = maxHealth;
        speed = powerLevel * speedPercent;
        attack = powerLevel * attackPercent;

        Debug.Log("Health at the beginning of the game");
        Debug.Log(currentHealth);

        // character animation
        charactAnimator = gameObject.GetComponent<Animator>();



    }

    public void Damage(float dmgAmount) {

        currentHealth -= dmgAmount;
        Debug.Log(currentHealth);

        if(currentHealth <= 0f)
        {
            Debug.Log("charact dead");
            charactAnimator.SetBool("Die", true);
            Invoke("DestroyCurrentCharact", 2);
        }



    }



    public float getHealthPercent() {
        return this.currentHealth / 100;
    }

    public float getAttack()
    {
        return attack;
    }


    public void DestroyCurrentCharact()
    {
        Destroy(this.gameObject);
    }

}