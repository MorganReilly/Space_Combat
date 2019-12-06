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

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private int maxLives = 3;
    private static int _remainingLives = 3;
    public static int RemainingLives
    {
        get { return _remainingLives; }
    }

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

        _remainingLives = maxLives;
    }

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
        // decrement remaining lives
        _remainingLives -= 1;
        // check if player is dead
        if (_remainingLives <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    public void EndGame()
    {
        // Debug.Log("GAME OVER!");

        gameOverUI.SetActive(true);
    }
}