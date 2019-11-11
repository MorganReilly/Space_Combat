using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/eSLx1-iA9RM

Class takes care of creation / destruction of game objects
 */
public class GameMaster : MonoBehaviour
{
    // Singleton pattern - 1 instance of class at given time
    public static GameMaster gm;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer()
    {
        
        // Countdown timer for spawn delay
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Player player) // Passing Player class as type --> Do same for enemy
    {
        // destroy player
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}