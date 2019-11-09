// xusing System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Inner class for player statistics
    [SerializeField]
    public class EnemyPlayerStats
    {
        public int maxEnemyPlayerHealth = 100;

        private int _curEnemyHealth;

        public int curEnemyHealth
        {
            get { return _curEnemyHealth; }
            // Setting a clamp on the setter so players health is set correctly to value
            set { _curEnemyHealth = Mathf.Clamp(value, 0, maxEnemyPlayerHealth); }
        }

        public void Init()
        {
            curEnemyHealth = maxEnemyPlayerHealth;
        }
    }

    // Cerate new enemy player stats object
    public EnemyPlayerStats enemyPlayerStats = new EnemyPlayerStats();

    [SerializeField] private StatusIndicator statusIndicator;

    // Variables
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Find temp location then subtract from it to
        // allow enemy movement 
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
} // class