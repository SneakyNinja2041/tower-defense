using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefabRed;
    public GameObject enemyPrefabGreen;
    public GameObject enemyPrefabBlue;

    private GameObject enemyToSpawn;
    private int randomTemp;

    public Transform spawnPoint;

    private int waveIndex = 0;

    public static List<GameObject> enemies = new List<GameObject>();
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0)
        {
            StartCoroutine(SpawnWave());
        }

    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < Mathf.RoundToInt(waveIndex + (waveIndex / 3)); i++)
        {
            SpawnEnemy();
            //Debug.Log(enemies.Count);
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        // Randomly generates which slime colour to spawn
        randomTemp = Random.Range(1, 11);
        if (randomTemp <= 6)
        {
            enemyToSpawn = enemyPrefabRed;
        }
        else if (randomTemp <= 9)
        {
            enemyToSpawn = enemyPrefabGreen;
        }
        else if (randomTemp == 10)
        {
            enemyToSpawn = enemyPrefabBlue;
        }
        else
        {
            enemyToSpawn = enemyPrefabRed; // Prevent potential null error
        }
        
        enemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        enemies.Add(enemy);
    }

}
