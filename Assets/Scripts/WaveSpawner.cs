using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefabRed;
    public GameObject enemyPrefabGreen;
    public GameObject enemyPrefabBlue;
    private string colour;

    private GameObject enemyToSpawn;
    private int randomTemp;

    public Transform spawnPoint;

    private int waveIndex = 0;

    public TextMeshProUGUI waveCounter;

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
        waveCounter.text = "Wave: " + waveIndex;
        PlayerStats.Rounds++;

        if (waveIndex % 10 == 0)
        {
            for (int i = 0; i < Mathf.RoundToInt(waveIndex + (waveIndex / 1.5f)); i++)
            {
                SpawnEnemy();
                //Debug.Log(enemies.Count);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            for (int i = 0; i < Mathf.RoundToInt(waveIndex + (waveIndex / 3)); i++)
            {
                SpawnEnemy();
                //Debug.Log(enemies.Count);
                yield return new WaitForSeconds(0.5f);
            }
        }
        
        
    }

    void SpawnEnemy()
    {
        if (waveIndex % 10 == 0) // If waveIndex is a multiple of 10
        {
            randomTemp = Random.Range(1, 11);
            if (randomTemp <= 5)
            {
                enemyToSpawn = enemyPrefabGreen;
                colour = "Green";
            }
            else if (randomTemp <= 10)
            {
                enemyToSpawn = enemyPrefabBlue;
                colour = "Blue";
            }
        }
        else
        {
            // Randomly generates which slime colour to spawn
            randomTemp = Random.Range(1, 11);
            if (randomTemp <= 6)
            {
                enemyToSpawn = enemyPrefabRed;
                colour = "Red";
            }
            else if (randomTemp <= 9)
            {
                enemyToSpawn = enemyPrefabGreen;
                colour = "Green";
            }
            else if (randomTemp == 10)
            {
                enemyToSpawn = enemyPrefabBlue;
                colour = "Blue";
            }
            else
            {
                enemyToSpawn = enemyPrefabRed; // Prevent potential null error
            }
        }
        
        
        
        enemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        enemies.Add(enemy);
        enemy.GetComponent<Enemy>().colour = colour;
    }

}
