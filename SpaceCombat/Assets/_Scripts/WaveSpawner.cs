using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public enum SpawnState
    {
        Spawning, Waiting, Counting
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState spawnState = SpawnState.Counting;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points Referenced");
        }
        
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (spawnState == SpawnState.Waiting)
        {
            // Check for any alive enemies
            if (!EnemyIsAlive())
            {
                // Begin new round
                WaveCompleted();
            }
            else
            {
                return; // Break out if any enemy is alive
            }
        }

        // Start spawning waves if <=0
        if (waveCountdown <= 0)
        {
            // Check if already spawning waves
            // if not: spawn waves
            if (spawnState != SpawnState.Spawning)
            {
                // Start wave spawn
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        spawnState = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves complete! Looping");

            // Can add difficulty multiplier here
            // Or could add game completed screen
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    // Want to be able to wait a certain amount of
    // time, so need to use IEnumerator
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        spawnState = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        spawnState = SpawnState.Waiting;
        yield break; // End IEnumerator
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy: " + _enemy.name);

        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
