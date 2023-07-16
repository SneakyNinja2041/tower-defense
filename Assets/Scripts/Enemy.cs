using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;

    private Animator animator;

    public int health = 10;
    public int value = 10;

    public string colour;

    public GameObject enemyPrefabRed;
    public GameObject enemyPrefabGreen;
    public GameObject enemyPrefabBlue;

    private GameObject enemy;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

        animator = GetComponent<Animator>();
    }

    public void TakeDamage (int amount)
    {
        
        health -= amount;
        animator.SetTrigger("Hurt");
        if (health <= 0)
        {

            Die();
        }
        
    }

    void Die()
    {
        PlayerStats.Money += value;

        if (colour == "Red")
        {
            animator.SetTrigger("Dead");
            WaveSpawner.enemies.Remove(this.gameObject);
            Destroy(gameObject);
        }
        else if (colour == "Green")
        {
            enemy = Instantiate(enemyPrefabRed, waypoints[waypointIndex].transform.position, this.transform.rotation);
            WaveSpawner.enemies.Remove(this.gameObject);
            WaveSpawner.enemies.Add(enemy);
            enemy.GetComponent<Enemy>().colour = "Red";
            enemy.GetComponent<Enemy>().waypointIndex = waypointIndex;
            Destroy(gameObject);
        }
        else if (colour == "Blue")
        {
            enemy = Instantiate(enemyPrefabGreen, waypoints[waypointIndex].transform.position, this.transform.rotation);
            WaveSpawner.enemies.Remove(this.gameObject);
            WaveSpawner.enemies.Add(enemy);
            enemy.GetComponent<Enemy>().colour = "Green";
            enemy.GetComponent<Enemy>().waypointIndex = waypointIndex;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        }

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex >= waypoints.Length - 1)
        {

            EndPath();
            return;
        }

    }

    void EndPath()
    {

        PlayerStats.Lives--;
        WaveSpawner.enemies.Remove(this.gameObject);
        Destroy(gameObject);
    }

}
