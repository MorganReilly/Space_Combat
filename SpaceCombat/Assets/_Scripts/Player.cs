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

    // Fall boundary
    public int fallBoundary = -10;

    // instatnce of playerstats class
    public PlayerStats playerStats = new PlayerStats();

    [Header("Optional: ")] // This tells unity to mark this as an optional field
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        playerStats.Init();

        if (statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
        }
    }

    // Update method
    void Update()
    {
        // Kill player if he goes out of bounds
        if (transform.position.y <= fallBoundary)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.curHealth -= damage;
        Debug.Log("Health: " + playerStats.curHealth);

        if (playerStats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
        statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
    }
}