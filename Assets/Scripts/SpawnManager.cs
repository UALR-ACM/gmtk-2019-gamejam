using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public PathWaypoint[] spawners;
	public Transform[] enemyPrefabs;
	public float baseSpawnRate;
	public int baseSpawnNumber;
	public float restTime;

	private int waveNumber = 0;
	private float currentSpawnRate;
	private int currentSpawnNumber;
	private float timeRemaining;
	private float timeToNextSpawn;
	private float remainingRestTime;

	private bool inSpawnMode;

	private void Start() {
		Random.InitState((int)Mathf.Ceil(Time.deltaTime * Time.time * 100));
		inSpawnMode = false;
		remainingRestTime = restTime;
	}

	private void Update() {
		if(inSpawnMode) {
			CheckSpawn();
		} else {
			CheckRestTime();
		}
	}

	private void CheckSpawn() {
		timeRemaining -= Time.deltaTime;
		timeToNextSpawn -= Time.deltaTime;

		if (timeToNextSpawn <= 0f) {
			Spawn();
			timeToNextSpawn += currentSpawnRate;
		}

		if(timeRemaining <= 0f) {
			remainingRestTime = restTime;
			inSpawnMode = false;
		}
	}

	private void Spawn() {
		int spawnerIdx = Random.Range(0, spawners.Length - 1);
		int prefabIdx = Random.Range(0, enemyPrefabs.Length - 1);

		Transform enemy = Instantiate(enemyPrefabs[prefabIdx]);
		GameObject enemyGO = enemy.gameObject;

		EnemyBehaviour behaviour = enemyGO.GetComponent<EnemyBehaviour>();
		EntityStats stats = enemyGO.GetComponent<EntityStats>();

		behaviour.currentWaypoint = spawners[spawnerIdx];
		//stats.SetPowerLevel(waveNumber * 10);
	}

	private void CheckRestTime() {
		remainingRestTime -= Time.deltaTime;

		if(remainingRestTime <= 0f) {
			inSpawnMode = true;
			PrepareForNextWave();
		}
	}

	private void PrepareForNextWave() {
		waveNumber++;
        //gameManager.GetComponent<GameManager>().gameLevel = waveNumber;

        currentSpawnRate = waveNumber * baseSpawnRate;
		currentSpawnNumber = waveNumber * baseSpawnNumber;

		timeRemaining = currentSpawnRate * currentSpawnNumber;
		timeToNextSpawn = currentSpawnRate;
	}
}
