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

    public int health = 10;
    public int value = 10;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        if (health <= 0)
        {

            Die();
        }

    }

    void Die()
    {
        PlayerStats.Money += value;

        Destroy(gameObject);
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
        Destroy(gameObject);
    }

}
