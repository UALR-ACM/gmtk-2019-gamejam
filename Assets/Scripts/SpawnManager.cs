using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public PathWaypoint[] spawnLocations;
	public Transform[] enemyPrefabs;
	public float baseSpawnRate;
	public int baseSpawnNumber;

	private int waveNumber;
	private float timeRemaining;

	private void Start() {
		Random.InitState((int)Mathf.Ceil(Time.deltaTime * Time.time * 100));
	}

	private void Update() {

	}

	private void Spawn() {
		int spawnerIdx = Random.Range(0, spawnLocations.Length - 1);
		int prefabIdx = Random.Range(0, enemyPrefabs.Length - 1);
	}
}
