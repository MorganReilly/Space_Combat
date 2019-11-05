﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/KKgtC_Gy65c
 */
public class Weapon : MonoBehaviour
{

    public float fireRate = 0; // Fire rate - single burst
    public float Damage = 10;// Damage
    public LayerMask toHit;

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
        Shoot(); // Debugging - Constant fire
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
            if (Input.GetKey(KeyCode.Space) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Raycasting code here
        Debug.Log("Shoot");
        // Change to single line ? 
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, toHit); // Origin, directon, distance, layerMask

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.black);

        // Check for collision detection
        if (hit.collider != null)
        {
            // Makes line of anything hit red
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("Hit object: " + hit.collider.name + " Damage dealt: " + Damage + " damage");
        }
    }
}