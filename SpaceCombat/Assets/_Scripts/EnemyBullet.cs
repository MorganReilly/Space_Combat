using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Fall boundary
    public int outOfBounds = -10;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update method
    void Update()
    {
        if (transform.position.y <= outOfBounds)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.DamagePlayer(10);
        }

        Destroy(gameObject);
    }
}