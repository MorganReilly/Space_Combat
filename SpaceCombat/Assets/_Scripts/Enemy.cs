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
        public int damage = 40;

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

    [SerializeField] public int fallBoundary = -20;

    [Header("Optional: ")] // This tells unity to mark this as an optional field
    [SerializeField]
    private StatusIndicator statusIndicator;

    public AudioSource audioSource;

    void Start()
    {
        enemyStats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }

    // Update method
    void Update()
    {
        // Debugging damage
        if (transform.position.y <= fallBoundary)
        {
            GameMaster.KillEnemy(this);
        }
    }

    public void DamageEnemy(int damage)
    {
        enemyStats.curHealth -= damage;

        if (enemyStats.curHealth <= 0)
        {
            // Die();
            audioSource.Play();
            GameMaster.KillEnemy(this);
            Debug.Log("Enemy Death by: Bullets");
        }

        // null check on statusIndicator
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            _player.DamagePlayer(enemyStats.damage);
            audioSource.Play();
            GameMaster.KillEnemy(this);
            Debug.Log("Enemy Death by: Collision");
        }
    }
}