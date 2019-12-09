using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/KKgtC_Gy65c
 */
public class Weapon : MonoBehaviour
{
    public float fireRate = 0; // Fire rate - single burst
    public float Damage = 10; // Damage
    public LayerMask toHit;

    public float timeToFire = 0; // place in time for next shot
    public Transform firePoint; // reference to firepoint

    public GameObject bulletPrefab;

    public AudioSource audioSource;

    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        // null check
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint found! Sort it.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot(); // Debugging - Constant fire
        // Check fire rate: single burst
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                audioSource.Play();
            }
        }
        // Not single burst
        else
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
                audioSource.Play();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}