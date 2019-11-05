using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/KKgtC_Gy65c
 */
public class Weapon : MonoBehaviour
{

    public float fireRate = 0; // Fire rate - single burst
    public float Damage = 10;// Damage
    public LayerMask notToHit;

    float timeToFire = 0; // place in time for next shot
    Transform firePoint; // 

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
        // Check fire rate: single burst
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        // Not single burst
        else
        {
            if (Input.GetKey(KeyCode.Space) && timeToFire.deltaTime > timeToFire)
            {
                timeToFire = Time.deltaTime + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Raycasting code here
        Debug.Log("Shoot");
    }
}
