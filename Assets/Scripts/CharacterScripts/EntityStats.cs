using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {

    public GameObject buffOrb;
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
        {
            float buffDrop = Random.Range(0, 100);

            if (buffDrop >= 50)
            {
                Instantiate(buffOrb, gameObject.transform.position, Quaternion.identity);
                Debug.Log("Orb spawned");
            }
            Destroy(this.gameObject);
        }

		if (currentHealth < 0f) {
            Destroy(this.gameObject);
            DeathCounter.IncrementTotalDeathCount();
        }
	}

	public float GetHealthPercentage() {
		return this.currentHealth / maxHealth;
	}

	public float GetAttack() {
		return attack;
	}

    public float GetSpeed() {
        return speed;
    }

	public void SetPowerLevel(float level) {
		powerLevel = level;
		
		maxHealth = healthPercent * powerLevel;
		currentHealth = maxHealth;
		speed = powerLevel * speedPercent;
		attack = powerLevel * attackPercent;
	}

    public void UpgradeAttack()
    {
        attack += 1;
    }

    public void UpgradeSpeed()
    {
        TankMouvement movement = gameObject.GetComponent<TankMouvement>();
        movement.speedMouvement += 0.5f;
    }

    public void UpgradeHealth()
    {
        if (currentHealth == maxHealth)
        {
            maxHealth += 4;
        }
        else
        {
            currentHealth += 3;
        }
    }
}