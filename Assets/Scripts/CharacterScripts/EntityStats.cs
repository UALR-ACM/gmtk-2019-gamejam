using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

	public float powerLevel;

	[Range(0f, 1f)]
	public float healthPercent;
	[Range(0f, 1f)]
	public float speedPercent;
	[Range(0f, 1f)]
	public float attackPercent;

    private bool isLiving;

	private float maxHealth;
	private float currentHealth;
	private float speed;
	private float attack;
    
    private Animator animController;
    
	private void Awake() {
		maxHealth = healthPercent * powerLevel;
		currentHealth = maxHealth;
		speed = powerLevel * speedPercent;
		attack = powerLevel * attackPercent;

        animController = transform.GetComponent<Animator>();

        isLiving = true;

    }


    public void Damage(float dmgAmount) {


        Debug.Log("damage made");
        Debug.Log(currentHealth);
		currentHealth -= dmgAmount;

		if (currentHealth <= 0f)
        {
            isLiving = false;
            animController.SetBool("Die", true);
            Invoke("DestroyCharact", 2);

        }


	}

	public float GetHealthPercentage() {
		return this.currentHealth / maxHealth;
	}

	public float GetAttack() {
		return attack;
	}
    
    private void DestroyCharact()
    {
        Destroy(this.gameObject);
    }
    public float GetSpeed() {
        return speed;
    }

    public bool GetLivingStatus()
    {
        return this.isLiving;
    }
}