using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewSpawnScript : MonoBehaviour
{

    public PathWaypoint[] spawners;
    public Transform[] enemyPrefabs;
    public TextMeshProUGUI waveTimer;

    private IEnumerator coroutine;

    private float TimeBetweenTwoEnnemiSpawn = 8.0f;

    private GameObject gameManager;

    public int numberOfEnimyByWaves = 1;

    void Start()
    {
        coroutine = WaitAndSpawn();
        StartCoroutine(coroutine);
        gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        //float TimeBetweenTwoEnnemiSpawn = 4.0f / gameManager.GetComponent<GameManager>().gameLevel;
        //Debug.Log("time between two spawn : " + TimeBetweenTwoEnnemiSpawn);

        waveTimer.SetText("Test");
    }

    private IEnumerator WaitAndSpawn()
    {

        

        while (true)
        {

            yield return new WaitForSeconds(TimeBetweenTwoEnnemiSpawn);
            //print("GameLevel : " + gameManager.GetComponent<GameManager>().gameLevel);
            TimeBetweenTwoEnnemiSpawn = 8.0f / gameManager.GetComponent<GameManager>().gameLevel;
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

            Debug.Log("Enemy spawn");

            GameObject enemy = Instantiate(enemyPrefabs[numPrefab]).gameObject;
            enemy.GetComponent<EnemyBehaviour>().currentWaypoint = spawners[numPath];

        }




    }
}
