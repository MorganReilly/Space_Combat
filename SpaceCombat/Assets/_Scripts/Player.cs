using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/eSLx1-iA9RM
 */
public class Player : MonoBehaviour
{
    // Player stats inner-class
    // Group functionality
    [System.Serializable] // Tells unity to display class
    public class PlayerStats
    {
        public int playerHealth = 100;
    }

    // instatnce of playerstats class
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -1;

    // Update method
    void Update()
    {
        // Debugging damage
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(101);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.playerHealth -= damage;

        if (playerStats.playerHealth <= 0)
        {
            Debug.Log("Kill Player");
            GameMaster.KillPlayer(this); // passes Player object
        }
    }


}
