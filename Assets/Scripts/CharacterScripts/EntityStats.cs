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

	private float maxHealth;
	private float currentHealth;
	private float speed;
	private float attack;

	private void Awake() {
		maxHealth = healthPercent * powerLevel;
		currentHealth = maxHealth;
		speed = powerLevel * speedPercent;
		attack = powerLevel * attackPercent;
	}

	public void Damage(float dmgAmount) {

		currentHealth -= dmgAmount;

		if (currentHealth < 0f)
			Destroy(this.gameObject);
	}

	public float GetHealthPercentage() {
		return this.currentHealth / maxHealth;
	}

	public float GetAttack() {
		return attack;
	}

    public float GetSpeed() {
        Debug.Log("Returning: " + speed);
        return speed;
    }
}