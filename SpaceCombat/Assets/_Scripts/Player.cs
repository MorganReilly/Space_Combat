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
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;

        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); } // Set constraints between 0 and max health.
        }

        // Set current health = maxHealth at game start
        // Can use for more later on
        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    // instatnce of playerstats class
    public PlayerStats playerStats = new PlayerStats();

    [Header("Optional: ")] // This tells unity to mark this as an optional field
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        playerStats.Init();

        // null check on statusIndicator
        if (statusIndicator == null)
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
        }
    }

    public int fallBoundary = -1;

    // Update method
    void Update()
    {
        // Kill player if he goes out of bounds
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(101);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.curHealth -= damage;
        Debug.Log("Health: " + playerStats.curHealth);

        if (playerStats.curHealth <= 0)
        {
            Die();
        }

        // null check on statusIndicator
        if (statusIndicator == null)
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
        }
    }

    void Die()
    {
        GameMaster.KillPlayer(this); // passes Player object
    }
}