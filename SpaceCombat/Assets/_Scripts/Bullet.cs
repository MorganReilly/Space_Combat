﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float outOfBounds = 4.5f;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (transform.position.y >= outOfBounds)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageEnemy(10);
        }

        Destroy(gameObject);
        GameMaster.CurrentScore += 10; // Increase score -- Enemy shot and killed
    }
}