using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;

    [Header("Attributes")]

    public float range = 15f; // How far the turret shoots from
    public float fireRate = 1f; // How fast the turret shoots per second
    private float fireCountdown = 0f;

    [Header("Unity Setup")]

    public string enemyTag = "Enemy";

    public GameObject bulletprefab;
    public Transform firePoint;
    public GameObject rangeUI;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
           
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    private void OnMouseOver()
    {
        rangeUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        rangeUI.SetActive(false);
    }


    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void ONDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
