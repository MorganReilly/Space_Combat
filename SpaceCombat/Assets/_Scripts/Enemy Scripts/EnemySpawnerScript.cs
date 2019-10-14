using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    // Variables
    public float min_X = -2.6f, max_X = 2.6f;

    public GameObject[] asteroid_prefabs;
    public GameObject enemyPrefab;

    public float timer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        if (Random.Range(0,2) > 0) {
            // 50 50 chance to spawn asteroid or enemy
            Instantiate(asteroid_prefabs[Random.Range(0, asteroid_prefabs.Length)],
            temp, Quaternion.identity);
        } else {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 180f));
        }

        Invoke("SpawnEnemies", timer);
    }
}
