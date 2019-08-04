using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewSpawnScript : MonoBehaviour
{

    public PathWaypoint[] spawners;
    public Transform[] enemyPrefabs;
    public TextMeshProUGUI waveTimerText;
    public TextMeshProUGUI waveCounterText;

    private IEnumerator coroutine;
    private IEnumerator coroutineTimer;

    private float TimeBetweenTwoEnnemiSpawn = 10.0f;

    private GameObject gameManager;

    public int numberOfEnimyByWaves = 1;
    private int waveCounter = 0;
    private float timeUntilNextWave;

    public float timer;

    void Start()
    {
        coroutine = WaitAndSpawn();
        StartCoroutine(coroutine);



        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {

        // not working
        //timer = Time.deltaTime;
        //timeUntilNextWave = TimeBetweenTwoEnnemiSpawn - timer;
        //waveTimerText.SetText(timeUntilNextWave.ToString());

    }

    private IEnumerator WaitAndSpawn()
    {

        

        while (true)
        {

            
            waveCounterText.SetText(waveCounter.ToString());

            yield return new WaitForSeconds(TimeBetweenTwoEnnemiSpawn);

            //print("GameLevel : " + gameManager.GetComponent<GameManager>().gameLevel);
            TimeBetweenTwoEnnemiSpawn = 10.0f / gameManager.GetComponent<GameManager>().gameLevel;

            waveCounterText.SetText(waveCounter.ToString());

            //print("Time between two spawn of enemi" + TimeBetweenTwoEnnemiSpawn);
            numberOfEnimyByWaves = 1 + gameManager.GetComponent<GameManager>().gameLevel;

            // If we want to create waves of ennemis it's here
            for (int i = 0; i < numberOfEnimyByWaves; i++)
            {
                //Debug.Log("Creating enemy number: " + i);
                var numPrefab = ChoosePrefab();
                var numPath = ChoosePath();
                InstanciateEnemi(numPrefab, numPath);

                // to be sure that 2 ennemies will not pop at the same place
                yield return new WaitForSeconds(0.5f);
            }

            waveCounter += 1;



        }

        int ChoosePrefab()
        {
            int prefabIdx = Random.Range(0, enemyPrefabs.Length);
            return prefabIdx;
        }

        int ChoosePath()
        {
            int spawnerIdx = Random.Range(0, enemyPrefabs.Length);
            return spawnerIdx;

        }

        void InstanciateEnemi(int numPrefab, int numPath)
        {

            //Debug.Log("Enemy spawn");

            GameObject enemy = Instantiate(enemyPrefabs[numPrefab]).gameObject;
            enemy.GetComponent<EnemyBehaviour>().currentWaypoint = spawners[numPath];

        }








    }



}
