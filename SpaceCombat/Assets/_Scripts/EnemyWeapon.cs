using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/KKgtC_Gy65c
 */
public class EnemyWeapon : MonoBehaviour
{
    public float fireRate = 0; // Fire rate - single burst
    public float Damage = 10; // Damage
    public LayerMask toHit;

    public float timeToFire = 0; // place in time for next shot
    public Transform firePoint; // reference to firepoint

    public GameObject bulletPrefab;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        // null check
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint found! Sort it.");
        }
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        // // Shoot(); // Debugging - Constant fire
        // // Check fire rate: single burst
        // if (fireRate == 0)
        // {
        //     Shoot();
        // }
        // // Not single burst
        // else
        // {
        //     timeToFire = Time.time + 1 / fireRate;
        //     Shoot();
        // }
        if (timeBetweenShots <= 0)
        {
            Shoot();
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}