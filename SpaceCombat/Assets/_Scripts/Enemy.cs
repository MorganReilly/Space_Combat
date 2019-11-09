using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy stats inner-class
    [System.Serializable]
    public class EnemyStats
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

    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")] // This tells unity to mark this as an optional field
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        enemyStats.Init();

        // null check on statusIndicator
        if (statusIndicator == null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }

    [SerializeField] public int fallBoundary = -50;

    // Update method
    void Update()
    {
        // Debugging damage
        if (transform.position.y <= fallBoundary)
        {
            DamageEnemy(101);
        }
    }

    public void DamageEnemy(int damage)
    {
        enemyStats.curHealth -= damage;

        if (enemyStats.curHealth <= 0)
        {
            Die();
        }

        // null check on statusIndicator
        if (statusIndicator == null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}