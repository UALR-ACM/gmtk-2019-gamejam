using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour {


	private float powerLevel = 10f;
    public GameObject buffOrb;
    

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
    
    private Animator animController;


    private GameObject gameManager;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        //Debug.Log("power level at instanciation : " + powerLevel.ToString());
        //Debug.Log("level of the game : " + gameManager.GetComponent<GameManager>().gameLevel);
        //Debug.Log("character stats : " + healthPercent.ToString());

        powerLevel = powerLevel * gameManager.GetComponent<GameManager>().gameLevel;

        maxHealth = healthPercent * powerLevel;
		currentHealth = maxHealth;
		speed = powerLevel * speedPercent;
		attack = powerLevel * attackPercent;

        animController = transform.GetComponent<Animator>();

        buffOrb = Resources.Load<GameObject>("UpgradeOrb");


        Debug.Log("Health at instanciation : " + maxHealth.ToString());


    }


    public void Damage(float dmgAmount) {


        //Debug.Log("damage made");
        //Debug.Log(currentHealth);
		currentHealth -= dmgAmount;

        if (currentHealth <= 0f)
        {

            this.GetComponent<EnemyBehaviour>().enabled = false;
            animController.SetBool("Walk", false);
            animController.SetBool("isIdle", true);
            animController.SetBool("Die", true);

            this.GetComponent<CapsuleCollider>().enabled = false;
            Invoke("DestroyCharact", 5);

            // increase level difficulty
            gameManager.GetComponent<GameManager>().numDeadEnemy += 1;
            if (gameManager.GetComponent<GameManager>().numDeadEnemy % 10 == 0)
            {
                gameManager.GetComponent<GameManager>().gameLevel++;
            }

            float buffDrop = Random.Range(0, 100);
            if (buffDrop >= 50)
            {
                Instantiate(buffOrb, gameObject.transform.position, Quaternion.identity);
                //Debug.Log("Orb spawned");
            }


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